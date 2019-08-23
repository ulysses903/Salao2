using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salao.Models;
using Salao.Services;
using Salao.Models.ViewModels;
using Salao.Services.Exceptions;
using System.Diagnostics;

namespace Salao.Controllers
{
    public class ServicosController : Controller
    {

        private readonly ServicoService _servicoService;
        private readonly FuncionariosService _funcionariosService;
        private readonly ClienteService _clienteService;
        private readonly ProcedimentosService _procedimentosService;

        public ServicosController(ServicoService servicoService, FuncionariosService funcionariosService, ClienteService clienteService, ProcedimentosService procedimentosService)
        {
            _servicoService = servicoService;
            _funcionariosService = funcionariosService;
            _clienteService = clienteService;
            _procedimentosService = procedimentosService;
        }

        public async Task<IActionResult> Index()
        {
            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            ViewData["minDate"] = Date.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = Date.ToString("yyyy-MM-dd");
            var result = await _servicoService.FindByDate2Async(Date, Date);
            return View(result);
        }

        public async Task<IActionResult> Amanha()
        {
            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            Date = Date.AddDays(1.0);
            ViewData["minDate"] = Date.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = Date.ToString("yyyy-MM-dd");
            var result = await _servicoService.FindByDate2Async(Date, Date);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var funcionarios = await _funcionariosService.FindAllAsync();
            var clientes = await _clienteService.FindAllAsync();
            var procedimentos = await _procedimentosService.FindAllAsync();
            var viewModel = new ServicosFormViewModel { Funcionarios = funcionarios, Clientes = clientes, Procedimentos = procedimentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Servico servico)
        {   
            if(!ModelState.IsValid)
            {
                var funcionarios = await _funcionariosService.FindAllAsync();
                var clientes = await _clienteService.FindAllAsync();
                var procedimentos = await _procedimentosService.FindAllAsync();
                var viewModel = new ServicosFormViewModel { Servico = servico, Funcionarios = funcionarios, Clientes = clientes, Procedimentos = procedimentos };
                return View(viewModel);
            }
            await _servicoService.InsertAsync(servico);
            return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _servicoService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Funcionario> funcionarios = await _funcionariosService.FindAllAsync();
            List<Cliente> clientes = await _clienteService.FindAllAsync();
            List<Procedimentos> procedimentos = await _procedimentosService.FindAllAsync();
            ServicosFormViewModel viewModel = new ServicosFormViewModel { Servico = obj, Funcionarios = funcionarios, Clientes = clientes, Procedimentos = procedimentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Servico servico)
        {
            if (!ModelState.IsValid)
            {
                var funcionarios = await _funcionariosService.FindAllAsync();
                var clientes = await _clienteService.FindAllAsync();
                var procedimentos = await _procedimentosService.FindAllAsync();
                var viewModel = new ServicosFormViewModel { Servico = servico, Funcionarios = funcionarios, Clientes = clientes, Procedimentos = procedimentos };
                return View(viewModel);
            }
            if (id != servico.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _servicoService.UpdateAsync(servico);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message});
            }
            catch (DbConcurrencyException e )
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _servicoService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _servicoService.FindByIdAsync(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Busca()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await  _servicoService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public IActionResult BuscaFuncionario()
        {
            return View();
        }

        public async Task<IActionResult> FuncSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _servicoService.FindByDate2Async(minDate, maxDate);
            return View(result);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
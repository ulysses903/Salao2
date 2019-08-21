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

        public IActionResult Index()
        {
            var list = _servicoService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var funcionarios = _funcionariosService.FindAll();
            var clientes = _clienteService.FindAll();
            var procedimentos = _procedimentosService.FindAll();
            var viewModel = new ServicosFormViewModel { Funcionarios = funcionarios, Clientes = clientes, Procedimentos = procedimentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Servico servico)
        {   
            if(!ModelState.IsValid)
            {
                var funcionarios = _funcionariosService.FindAll();
                var clientes = _clienteService.FindAll();
                var procedimentos = _procedimentosService.FindAll();
                var viewModel = new ServicosFormViewModel { Servico = servico, Funcionarios = funcionarios, Clientes = clientes, Procedimentos = procedimentos };
                return View(viewModel);
            }
            _servicoService.Insert(servico);
            return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _servicoService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Funcionario> funcionarios = _funcionariosService.FindAll();
            List<Cliente> clientes = _clienteService.FindAll();
            List<Procedimentos> procedimentos = _procedimentosService.FindAll();
            ServicosFormViewModel viewModel = new ServicosFormViewModel { Servico = obj, Funcionarios = funcionarios, Clientes = clientes, Procedimentos = procedimentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Servico servico)
        {
            if (!ModelState.IsValid)
            {
                var funcionarios = _funcionariosService.FindAll();
                var clientes = _clienteService.FindAll();
                var procedimentos = _procedimentosService.FindAll();
                var viewModel = new ServicosFormViewModel { Servico = servico, Funcionarios = funcionarios, Clientes = clientes, Procedimentos = procedimentos };
                return View(viewModel);
            }
            if (id != servico.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                _servicoService.Update(servico);
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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _servicoService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _servicoService.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
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
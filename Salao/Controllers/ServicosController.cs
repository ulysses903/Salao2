using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salao.Models;
using Salao.Services;
using Salao.Models.ViewModels;
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
            _servicoService.Insert(servico);
            return RedirectToAction(nameof(Index));
            
        }

    }
}
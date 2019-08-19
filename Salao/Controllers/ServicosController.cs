using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Salao.Controllers
{
    public class ServicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
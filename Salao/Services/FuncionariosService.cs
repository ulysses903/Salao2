using Salao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salao.Services
{
    public class FuncionariosService
    {
        private readonly SalaoContext _context;

        public FuncionariosService(SalaoContext context)
        {
            _context = context;
        }

        public List<Funcionario> FindAll()
        {
            return _context.Funcionario.OrderBy(x => x.Name).ToList();
        }

    }
}

using Salao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salao.Services
{
    public class ProcedimentosService
    {
        private readonly SalaoContext _context;

        public ProcedimentosService(SalaoContext context)
        {
            _context = context;
        }

        public List<Procedimentos> FindAll()
        {
            return _context.Procedimentos.OrderBy(x => x.Name).ToList();
        }
    }
}


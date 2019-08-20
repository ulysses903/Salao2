using Salao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salao.Services
{
    public class ClienteService
    {
        private readonly SalaoContext _context;

        public ClienteService (SalaoContext context)
        {
            _context = context;
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.OrderBy(x => x.Name).ToList();
        }
    }
}

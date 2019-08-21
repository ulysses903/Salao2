using Salao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Salao.Services
{
    public class FuncionariosService
    {
        private readonly SalaoContext _context;

        public FuncionariosService(SalaoContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> FindAllAsync()
        {
            return await _context.Funcionario.OrderBy(x => x.Name).ToListAsync();
        }

    }
}

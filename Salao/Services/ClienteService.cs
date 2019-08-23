using Salao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Salao.Services
{
    public class ClienteService
    {
        private readonly SalaoContext _context;

        public ClienteService (SalaoContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Cliente.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<Cliente>> FindByBirthDate(DateTime? Date)
        {
            var result = from obj in _context.Cliente select obj;
            if (Date.HasValue)
            {
                result = result.Where(x => x.BirthDate.Month == Date.Value.Month);
            }
            return await result
                .OrderByDescending(x => x.BirthDate)
                .ToListAsync();
        }
    }
}

﻿using Salao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Salao.Services
{
    public class ProcedimentosService
    {
        private readonly SalaoContext _context;

        public ProcedimentosService(SalaoContext context)
        {
            _context = context;
        }

        public async Task<List<Procedimentos>> FindAllAsync()
        {
            return await _context.Procedimentos.OrderBy(x => x.Name).ToListAsync();
        }
    }
}


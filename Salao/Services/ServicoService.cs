using Salao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salao.Services.Exceptions;

namespace Salao.Services
{
    public class ServicoService
    {
        private readonly SalaoContext _context;

        public ServicoService(SalaoContext context)
        {
            _context = context;
        }

        public async Task<List<Servico>> FindAllAsync()
        {
            return await _context
                .Servico
                .Include(obj => obj.Funcionario)
                .Include(obj => obj.Cliente)
                .Include(obj => obj.Procedimentos)
                .ToListAsync();
        }

        public async Task InsertAsync(Servico obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Servico> FindByIdAsync(int id)
        {
            return await _context
                .Servico
                .Include(obj => obj.Funcionario)
                .Include(obj => obj.Cliente)
                .Include(obj => obj.Procedimentos)
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Servico.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Servico obj)
        {
            bool hasAny = await _context.Servico.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync ();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<List<Servico>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Servico select obj;
            maxDate = maxDate.Value.AddDays(1.0);
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Cliente)
                .Include(x => x.Funcionario)
                .Include(x => x.Procedimentos)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<Servico>> FindByDateAndByFuncionarioAsync(DateTime? minDate, DateTime? maxDate, int funcionarioId)
        {
            var result = from obj in _context.Servico select obj;
            maxDate = maxDate.Value.AddDays(1.0);
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value && x.FuncionarioId == funcionarioId);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value && x.FuncionarioId == funcionarioId);
            }
            return await result
                .Include(x => x.Cliente)
                .Include(x => x.Funcionario)
                .Include(x => x.Procedimentos)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Funcionario, Servico>>> FindByDate2Async(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Servico select obj;
            maxDate = maxDate.Value.AddDays(1.0);
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Cliente)
                .Include(x => x.Funcionario)
                .Include(x => x.Procedimentos)
                .OrderBy(x => x.Date)
                .GroupBy(x => x.Funcionario)
                .ToListAsync();
        }

    }
}

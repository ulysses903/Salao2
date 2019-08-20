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

        public List<Servico> FindAll()
        {
            return _context.Servico.Include(obj => obj.Funcionario).Include(obj => obj.Cliente).Include(obj => obj.Procedimentos).ToList();
        }

        public void Insert (Servico obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Servico FindById(int id)
        {
            return _context.Servico.Include(obj => obj.Funcionario).Include(obj => obj.Cliente).Include(obj => obj.Procedimentos).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Servico.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Servico obj)
        {
            if (!_context.Servico.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado.");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}

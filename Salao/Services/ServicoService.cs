using Salao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.Servico.ToList();
        }

        public void Insert (Servico obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Servico FindById(int id)
        {
            return _context.Servico.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Servico.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }

    }
}

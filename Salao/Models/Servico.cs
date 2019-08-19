using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salao.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public Procedimentos Procedimentos { get; set; }

        public Servico()
        {
        }

        public Servico(int id, DateTime date, double price, Funcionario funcionario, Cliente cliente, Procedimentos procedimentos)
        {
            Id = id;
            Date = date;
            Price = price;
            Funcionario = funcionario;
            Cliente = cliente;
            Procedimentos = procedimentos;
        }
    }
}

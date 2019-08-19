using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Salao.Models
{
    public class Servico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Prçeo")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
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

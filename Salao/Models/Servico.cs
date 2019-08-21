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

        [Required(ErrorMessage = "{0} necessário")]
        [Display(Name = "Dia e Horario")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy | HH:mm}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} necessário")]
        //[Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Price { get; set; }

        public Funcionario Funcionario { get; set; }
        [Display(Name = "Funcionario")]
        public int FuncionarioId { get; set; }
        public Cliente Cliente { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Procedimentos Procedimentos { get; set; }
        [Display(Name = "Procedimentos")]
        public int ProcedimentosId { get; set; }

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Salao.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Nome")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Número de Telefone")]
        public string PhoneNumber { get; set; }
        public ICollection<Servico> Sales { get; set; } = new List<Servico>();

        public Funcionario()
        {
        }

        public Funcionario(int id, string name, DateTime birthDate, string phoneNumber)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            final = final.AddDays(1.0);
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Price);
        }

    }
}

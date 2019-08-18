using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Salao.Models
{
    public class Cliente
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

        public string PhoneNumber { get; set; }
        


        public Cliente()
        {
        }

        public Cliente(int id, string name, DateTime birthDate, string phoneNumber)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
        }

        
    }
}

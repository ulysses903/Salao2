using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salao.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(int id, string name, DateTime birthDate, int phoneNumber)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
        }
    }
}

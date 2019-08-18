using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salao.Models
{
    public class Procedimentos
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Procedimentos()
        {
        }

        public Procedimentos(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salao.Models.ViewModels
{
    public class FuncionariosFormViewModel
    {
        public Servico Servico { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }

    }
}

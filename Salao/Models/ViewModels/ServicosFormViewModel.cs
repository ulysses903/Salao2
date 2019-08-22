using System.Collections.Generic;

namespace Salao.Models.ViewModels
{
    public class ServicosFormViewModel
    {
        public Servico Servico { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Procedimentos> Procedimentos { get; set; }


    }
}

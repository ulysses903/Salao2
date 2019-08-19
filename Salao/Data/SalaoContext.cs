using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salao.Models;

namespace Salao.Models
{
    public class SalaoContext : DbContext
    {
        public SalaoContext (DbContextOptions<SalaoContext> options)
            : base(options)
        {
        }

        public DbSet<Procedimentos> Procedimentos { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Funcionario> Funcionario { get; set; }

        public DbSet<Servico> Servico { get; set; }
    }
}

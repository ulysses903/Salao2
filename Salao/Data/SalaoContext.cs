using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Salao.Models
{
    public class SalaoContext : DbContext
    {
        public SalaoContext (DbContextOptions<SalaoContext> options)
            : base(options)
        {
        }

        public DbSet<Salao.Models.Procedimentos> Procedimentos { get; set; }
    }
}

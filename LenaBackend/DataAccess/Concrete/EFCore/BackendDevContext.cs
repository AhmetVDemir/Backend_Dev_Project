using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EFCore
{
    public class BackendDevContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=B166ER;Database=BackendDecSQL;Trusted_Connection=true;TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<BaseForm> Forms { get; set; }

        public DbSet<Field> Fields { get; set; }

    }
}
 
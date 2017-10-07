using Empresa.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Repositorios.SqlServer
{
    public class EmpresaDbContext: DbContext
    {
        public EmpresaDbContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

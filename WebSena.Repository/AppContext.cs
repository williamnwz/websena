using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;
using WebSena.Repository.Mapping;

namespace WebSena.Repository
{
    public class AppContext : DbContext
    {
        public AppContext() : base("websena")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConcursoMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Concurso> Concursos { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Local> Locais { get; set; }

        public DbSet<Premio> Premios { get; set; }

        public DbSet<NumeroSorteado> NumeroSorteados { get; set; }
    }
}

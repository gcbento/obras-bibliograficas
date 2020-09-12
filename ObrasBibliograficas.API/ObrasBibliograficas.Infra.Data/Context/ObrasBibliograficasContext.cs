using Microsoft.EntityFrameworkCore;
using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Infra.Data.Configs;
using System;

namespace ObrasBibliograficas.Infra.Data.Context
{
    public class ObrasBibliograficasContext : DbContext
    {
        public ObrasBibliograficasContext(DbContextOptions<ObrasBibliograficasContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}

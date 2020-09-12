using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObrasBibliograficas.Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Infra.Data.Configs
{
    public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(300)")
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}

using FinancasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento da entidade Movimentação
    /// </summary>
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            //nome da tabela
            builder.ToTable("MOVIMENTACOES");

            //chave primaria
            builder.HasKey(m => m.Id);

            //propriedades
            builder.Property(m => m.Id).HasColumnName("ID");
            builder.Property(m => m.Nome).HasColumnName("NOME").HasMaxLength(150);
            builder.Property(m => m.Data).HasColumnName("DATA").HasColumnType("date");
            builder.Property(m => m.Valor).HasColumnName("VALOR").HasColumnType("decimal(10,2)");
            builder.Property(m => m.Tipo).HasColumnName("TIPO").HasColumnType("int");
            builder.Property(m => m.CategoriaId).HasColumnName("CATEGORIA_ID");

            //relacionamentos
            builder.HasOne(m => m.Categoria) //Movimentação TEM 1 Categoria
                .WithMany(c => c.Movimentacoes) //Categoria TEM MUITAS Movimentações
                .HasForeignKey(m => m.CategoriaId); //Chave estrangeira em Movimentação
        }
    }
}

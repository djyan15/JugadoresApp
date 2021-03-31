using Jugadores.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jugadores.Infrastructure.Data.Configurations
{
    public  class EquipoConfiguration : IEntityTypeConfiguration<Equipos>
    {

        public void Configure(EntityTypeBuilder<Equipos> builder)
        {
            builder.ToTable("Equipos");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
            .HasColumnName("EquipoId");

            builder.Property(e => e.EquipoEstado)
                  .HasColumnName("EquipoEstado")
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

            builder.Property(e => e.EquipoFechaCreacion)
                            .HasColumnType("datetime")
                            .HasColumnName("EquipoFechaCreacion")
                            .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.EquipoNombre)
                            .IsRequired()
                            .HasColumnName("EquipoNombre")
                            .HasMaxLength(50)
                            .IsUnicode(false);

            builder.Property(e => e.EquipoPais)
                            .IsRequired()
                            .HasColumnName("EquipoPais")
                            .HasMaxLength(3)
                            .IsUnicode(false)
                            .IsFixedLength(true);
        

        }

    }
}

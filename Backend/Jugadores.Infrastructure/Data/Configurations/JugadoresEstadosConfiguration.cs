using Jugadores.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jugadores.Infrastructure.Data.Configurations
{
    public class JugadoresEstadosConfiguration : IEntityTypeConfiguration<JugadoresEstado>
    {
        public void Configure(EntityTypeBuilder<JugadoresEstado> builder)
        {

            builder.HasKey(e => e.Id);

            builder.ToTable("Jugadores_Estados");

            builder.Property(e => e.Id)
                   .HasColumnName("EstadoId");

            builder.Property(e => e.EstadoFechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("EstadoFechaCreacion")
                    .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.EstadoNombre)
                    .HasColumnName("EstadoNombre")
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

        }

    }
}

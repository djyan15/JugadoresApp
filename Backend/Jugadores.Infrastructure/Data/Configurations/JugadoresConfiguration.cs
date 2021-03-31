using Jugadores.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jugadores.Infrastructure.Data.Configurations
{
   public class JugadoresConfiguration : IEntityTypeConfiguration<Jugador>
    {
        public void Configure(EntityTypeBuilder<Jugador> builder)
        {
            builder.ToTable("Jugadores");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                 .HasColumnName("JugadorId");


            builder.Property(e => e.JugadorApellido)
                    .IsRequired()
                   .HasColumnName("JugadorApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.JugadorFechaNacimiento).
                   HasColumnName("JugadorFechaNacimiento").
                HasColumnType("datetime");

            builder.Property(e => e.JugadorNombre)
                    .IsRequired()
                    .HasColumnName("JugadorNombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.JugadorPasaporte)
                    .HasColumnName("JugadorPasaporte")
                    .HasMaxLength(20)
                    .IsUnicode(false);

            builder.Property(e => e.JugadorSexo)
                    .IsRequired()
                    .HasColumnName("JugadorSexo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

            builder.HasOne(d => d.Equipo)
                    .WithMany(p => p.Jugadores)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jugadores_Equipos");

            builder.HasOne(d => d.Estado)
                    .WithMany(p => p.Jugadores)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jugadores_Jugadores_Estados");
        

        }

    }
}

using System;
using Jugadores.Core.Data;
using Jugadores.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Jugadores.Infrastructure.Data
{
    public partial class JuegosContext : DbContext
    {
        public JuegosContext()
        {
        }

        public JuegosContext(DbContextOptions<JuegosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipos> Equipo { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<JugadoresEstado> JugadoresEstados { get; set; }

 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EquipoConfiguration());
            modelBuilder.ApplyConfiguration(new JugadoresConfiguration());
            modelBuilder.ApplyConfiguration(new JugadoresEstadosConfiguration());

        }

      
    }
}

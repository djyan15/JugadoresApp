using Jugadores.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Jugadores.Core.Data
{
    public partial class Jugador : BaseEntity
    {
        //public int JugadorId { get; set; }
        public string JugadorNombre { get; set; }
        public string JugadorApellido { get; set; }
        public DateTime JugadorFechaNacimiento { get; set; }
        public string JugadorPasaporte { get; set; }
        public string JugadorSexo { get; set; }
        public int EquipoId { get; set; }
        public int EstadoId { get; set; }

        public virtual Equipos Equipo { get; set; }
        public virtual JugadoresEstado Estado { get; set; }
    }
}

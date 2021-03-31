using Jugadores.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Jugadores.Core.Data
{
    public partial class JugadoresEstado : BaseEntity
    {
        public JugadoresEstado()
        {
            Jugadores = new HashSet<Jugador>();
        }

        //public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
        public DateTime EstadoFechaCreacion { get; set; }

        public virtual ICollection<Jugador> Jugadores { get; set; }
    }
}

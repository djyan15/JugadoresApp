using Jugadores.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Jugadores.Core.Data
{
    public partial class Equipos : BaseEntity
    {
        public Equipos()
        {
            Jugadores = new HashSet<Jugador>();
        }

        //public int EquipoId { get; set; }
        public string EquipoNombre { get; set; }
        public string EquipoPais { get; set; }
        public string EquipoEstado { get; set; }
        public DateTime? EquipoFechaCreacion { get; set; }

        public virtual ICollection<Jugador> Jugadores { get; set; }
    }
}

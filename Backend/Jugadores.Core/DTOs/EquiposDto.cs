using Jugadores.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jugadores.Core.DTOs
{
   public class EquiposDto : BaseEntity
    {
        public string EquipoNombre { get; set; }
        public string EquipoPais { get; set; }
        public string EquipoEstado { get; set; }
        public DateTime? EquipoFechaCreacion { get; set; }
    }
}

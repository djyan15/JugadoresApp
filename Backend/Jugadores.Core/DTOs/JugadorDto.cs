using Jugadores.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jugadores.Core.DTOs
{
   public class JugadorDto : BaseEntity
    {
        public string JugadorNombre { get; set; }
        public string JugadorApellido { get; set; }
        public DateTime JugadorFechaNacimiento { get; set; }
        public string JugadorPasaporte { get; set; }
        public string JugadorSexo { get; set; }
        public int EquipoId { get; set; }
        public int EstadoId { get; set; }

    }
}

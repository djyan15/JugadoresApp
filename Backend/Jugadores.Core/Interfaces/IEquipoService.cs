using Jugadores.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jugadores.Core.Interfaces
{
    public interface IEquipoService
    {

        IEnumerable<Equipos> GetEquipos();
        Task<Equipos> GetEquipo(int id);

        Task InsertEquipo(Equipos equipo);
        Task<bool> UpdateEquipo(Equipos equipo);
        Task<bool> DeleteEquipo(int id);
    }
}

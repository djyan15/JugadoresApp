using Jugadores.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jugadores.Core.Interfaces
{
  public interface IEquipoRepository : IRepository<Equipos>
    {
        Task<IEnumerable<Equipos>> GetEquiposByStatus(string Status);

    }
}

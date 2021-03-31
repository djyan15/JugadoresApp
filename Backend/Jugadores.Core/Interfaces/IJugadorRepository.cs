using Jugadores.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jugadores.Core.Interfaces
{
    public interface IJugadorRepository: IRepository<Jugador>
    {
        Task<IEnumerable<Jugador>> GetJugadoresByEquipos(int EquipoId);
        Task<IEnumerable<Jugador>> GetJugadoresByStatus(int EstadoId);
    }
}
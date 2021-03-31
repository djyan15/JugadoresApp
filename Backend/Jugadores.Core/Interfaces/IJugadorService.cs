using Jugadores.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jugadores.Core.Services
{
    public interface IJugadorService
    {
        Task<bool> DeleteJugador(int id);
        IEnumerable<Jugador> GetJugadores();
        Task<Jugador> GetJugador(int id);
        Task InsertJugador(Jugador jugador);
        Task<bool> UpdateJugador(Jugador jugador);
    }
}
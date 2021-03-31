using Jugadores.Core.Data;
using Jugadores.Core.Interfaces;
using Jugadores.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jugadores.Infrastructure.Repositories
{
    public class JugadorRepository : BaseRepository<Jugador>, IJugadorRepository
    {


        public JugadorRepository(JuegosContext context) : base(context)
        {

        }
      
        public async Task<IEnumerable<Jugador>> GetJugadoresByEquipos(int EquipoId)
        {
            return  await _entities.Where(x => x.EquipoId == EquipoId).ToListAsync();
        }

        public async Task<IEnumerable<Jugador>> GetJugadoresByStatus(int EstadoId)
        {
            return await  _entities.Where(x => x.EstadoId == EstadoId).ToListAsync();
        }
    }
}

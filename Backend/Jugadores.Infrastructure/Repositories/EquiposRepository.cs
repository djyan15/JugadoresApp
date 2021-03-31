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
    public class EquiposRepository: BaseRepository<Equipos>, IEquipoRepository
    {


        public EquiposRepository(JuegosContext context) : base (context)
        {
         
        }

        public async Task<IEnumerable<Equipos>> GetEquiposByStatus(string Status)
        {
            return await _entities.Where(x => x.EquipoEstado == Status).ToListAsync();
        }
    }
}

using Jugadores.Core.Data;
using Jugadores.Core.Interfaces;
using Jugadores.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jugadores.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public readonly JuegosContext _context;
        private readonly IEquipoRepository _equipoRepository;
        private readonly IJugadorRepository _JugadorRepository;
        private readonly IRepository<JugadoresEstado> _jugadoresEstadoRepository;

        public UnitOfWork(JuegosContext context)
        {
            _context = context;
        }

        public IJugadorRepository JugadorRepository => _JugadorRepository ?? new JugadorRepository(_context);

        public IEquipoRepository EquipoRepository => _equipoRepository ?? new EquiposRepository(_context);

        public IRepository<JugadoresEstado> JugadoresEstadosRepository => _jugadoresEstadoRepository ?? new BaseRepository<JugadoresEstado>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

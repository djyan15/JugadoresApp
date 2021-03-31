using Jugadores.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jugadores.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IJugadorRepository JugadorRepository { get; }
        IEquipoRepository EquipoRepository { get; }
        IRepository<JugadoresEstado> JugadoresEstadosRepository { get; }

        void SaveChanges();  
        Task SaveChangesAsync();
    }
}

using Jugadores.Core.Data;
using Jugadores.Core.Exceptions;
using Jugadores.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jugadores.Core.Services
{
    public class JugadorService : IJugadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public JugadorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<Jugador> GetJugadores()
        {
            return _unitOfWork.JugadorRepository.GetAll();

        }

        public async Task<Jugador> GetJugador(int id)
        {
            return await _unitOfWork.JugadorRepository.GetById(id);

        }

        public async Task InsertJugador(Jugador jugador)
        {
            var equipo = await _unitOfWork.EquipoRepository.GetById(jugador.EquipoId);

            if (equipo == null)
            {
                throw new BusinessException("El equipo no existe para poder ingresar el jugador");
            }
            await _unitOfWork.JugadorRepository.Add(jugador);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateJugador(Jugador jugador)
        {
            _unitOfWork.JugadorRepository.Update(jugador);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteJugador(int id)
        {
            await _unitOfWork.JugadorRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}

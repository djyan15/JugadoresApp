using Jugadores.Core.Data;
using Jugadores.Core.Exceptions;
using Jugadores.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jugadores.Core.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EquipoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Equipos> GetEquipo(int id)
        {
   
            return await _unitOfWork.EquipoRepository.GetById(id);
        }

        public IEnumerable<Equipos> GetEquipos()
        {
            return _unitOfWork.EquipoRepository.GetAll();
        }

        public async Task InsertEquipo(Equipos equipo)
        {

            await _unitOfWork.EquipoRepository.Add(equipo);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<bool> UpdateEquipo(Equipos equipo)
        {
            _unitOfWork.EquipoRepository.Update(equipo);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEquipo(int id)
        {
            await _unitOfWork.EquipoRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

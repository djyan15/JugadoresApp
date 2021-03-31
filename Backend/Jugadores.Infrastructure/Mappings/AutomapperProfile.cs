using Jugadores.Core.Data;
using Jugadores.Core.DTOs;
using AutoMapper;

namespace Jugadores.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {

        public AutomapperProfile()
        {
            CreateMap<Equipos, EquiposDto>();
            CreateMap<EquiposDto, Equipos>();
            CreateMap<Jugador, JugadorDto>();
            CreateMap<JugadorDto, Jugador>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jugadores.API.Responses;
using Jugadores.Core.Data;
using Jugadores.Core.DTOs;
using Jugadores.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jugadores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {

        private readonly IJugadorService _jugadorService;
        private readonly IMapper _mapper;

        public JugadorController(IJugadorService jugadorService, IMapper mapper)
        {
            _jugadorService = jugadorService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetJugadores()
        {
            var jugadores = _jugadorService.GetJugadores();

            var jugadoresDto = _mapper.Map<IEnumerable<JugadorDto>>(jugadores);

            var response = new ApiResponse<IEnumerable<JugadorDto>>(jugadoresDto);

            return Ok(response);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJugador(int id)
        {
            var jugadores = await _jugadorService.GetJugador(id);

            var jugadoresDto = _mapper.Map<JugadorDto>(jugadores);


            var response = new ApiResponse<JugadorDto>(jugadoresDto);
            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> PostJugador(JugadorDto jugadoresDto)
        {
            
            var jugadores = _mapper.Map<Jugador>(jugadoresDto);

            await _jugadorService.InsertJugador(jugadores);

            jugadoresDto = _mapper.Map<JugadorDto>(jugadores);

            var response = new ApiResponse<JugadorDto>(jugadoresDto);

            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> PutJugador(int id, JugadorDto jugadoresDto)
        {

            var jugadores = _mapper.Map<Jugador>(jugadoresDto);
            jugadores.Id = id;

            var result = await _jugadorService.UpdateJugador(jugadores);

            var response = new ApiResponse<bool>(result);

            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJugador(int id)
        {

            var result = await _jugadorService.DeleteJugador(id);

            var response = new ApiResponse<bool>(result);

            return Ok(response);

        }
    }
}
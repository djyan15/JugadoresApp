using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jugadores.API.Responses;
using Jugadores.Core.Data;
using Jugadores.Core.DTOs;
using Jugadores.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jugadores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquipoService _equipoService;
        private readonly IMapper _mapper;


        public EquipoController(IEquipoService equipoService, IMapper mapper)
        {
            _equipoService = equipoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEquipos()
        {
            var equipos = _equipoService.GetEquipos();

            var equiposDto = _mapper.Map<IEnumerable<EquiposDto>>(equipos);

            var response = new ApiResponse<IEnumerable<EquiposDto>>(equiposDto);

            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquipo(int id)
        {
            var equipos = await _equipoService.GetEquipo(id);

            var equiposDto = _mapper.Map<EquiposDto>(equipos);


            var response = new ApiResponse<EquiposDto>(equiposDto);
            return Ok(response);

        }
        //[HttpGet()]
        //public async Task<IActionResult> GetEquipoByStatus(string Status)
        //{
        //    var equipos = await _equipoService.GetEquipo(id);

        //    var equiposDto = _mapper.Map<EquiposDto>(equipos);


        //    var response = new ApiResponse<EquiposDto>(equiposDto);
        //    return Ok(response);

        //}
        [HttpPost]
        public async Task<IActionResult> PostEquipo(EquiposDto equiposDto)
        {
            var equipo = _mapper.Map<Equipos>(equiposDto);

            await _equipoService.InsertEquipo(equipo);

            equiposDto = _mapper.Map<EquiposDto>(equipo);

            var response = new ApiResponse<EquiposDto>(equiposDto);

            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> PutEquipo(int id, EquiposDto equiposDto)
        {
            var equipo = _mapper.Map<Equipos>(equiposDto);
            equipo.Id = id;

            var result = await _equipoService.UpdateEquipo(equipo);
            var response = new ApiResponse<bool>(result);

            return Ok(response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo(int id)
        {
            var result = await _equipoService.DeleteEquipo(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrabajoFinalBE.Dtos;
using TrabajoFinalBE.Models;
using TrabajoFinalBE.Repository;

namespace TrabajoFinalBE.Controllers
{
    // Attribute routing para cada uno de los controllers
    [Route("api/[controller]")]
    [ApiController]
    public class AhorrosController : ControllerBase
    {
        private readonly IAhorroRepository _ahorroRepo;
        private readonly IMapper _mapper;

        public AhorrosController(IAhorroRepository ahorroRepo, IMapper mapper)
        {
            _ahorroRepo = ahorroRepo;
            _mapper = mapper;
        }

        // GET para ahorros
        [HttpGet]
        public async Task<IActionResult> GetAhorros()
        {
            var listaAhorros = await _ahorroRepo.GetAhorrosAsync();
            var listaAhorrosDto = _mapper.Map<List<AhorroDto>>(listaAhorros);
            return Ok(listaAhorrosDto);
        }

        // Obtenemos el id del ahorro
        [HttpGet("{id}", Name = "GetAhorro")]
        public async Task<IActionResult> GetAhorro(int id)
        {
            var itemAhorro = await _ahorroRepo.GetAhorroAsync(id);
            if (itemAhorro == null)
            {
                return NotFound();
            }
            var itemAhorroDto = _mapper.Map<AhorroDto>(itemAhorro);
            return Ok(itemAhorroDto);
        }

        // POST para ahorros
        [HttpPost]
        public async Task<IActionResult> CrearAhorro([FromBody] CreateAhorroDto createAhorroDto)
        {
            if (createAhorroDto == null)
            {
                return BadRequest(ModelState);
            }

            var ahorro = _mapper.Map<Ahorro>(createAhorroDto);
            ahorro.MontoActual = 0; 
            ahorro.EsActiva = true;

            if (!await _ahorroRepo.CrearAhorroAsync(ahorro))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {ahorro.DescripcionMeta}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetAhorro", new { id = ahorro.Id }, ahorro);
        }

        // Patch para modificar montos
        [HttpPatch("{id}")]
        public async Task<IActionResult> ActualizarMonto(int id, [FromBody] decimal nuevoMonto)
        {
            if (!await _ahorroRepo.ExisteAhorroAsync(id))
            {
                return NotFound();
            }

            var ahorroObj = await _ahorroRepo.GetAhorroAsync(id);
            ahorroObj.MontoActual += nuevoMonto; 

            if (!await _ahorroRepo.ActualizarAhorroAsync(ahorroObj))
            {
                ModelState.AddModelError("", $"Algo salió mal actualizando el registro {ahorroObj.DescripcionMeta}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        // El DELETE del id para el ahorro seleccionado
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarAhorro(int id)
        {
            if (!await _ahorroRepo.ExisteAhorroAsync(id))
            {
                return NotFound();
            }

            var ahorroObj = await _ahorroRepo.GetAhorroAsync(id);

            if (!await _ahorroRepo.BorrarAhorroAsync(ahorroObj))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {ahorroObj.DescripcionMeta}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
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
    public class TransferenciasController : ControllerBase
    {
        private readonly ITransferenciaRepository _transRepo;
        private readonly IMapper _mapper;

        public TransferenciasController(ITransferenciaRepository transRepo, IMapper mapper)
        {
            _transRepo = transRepo;
            _mapper = mapper;
        }

        // GET de transferencias
        [HttpGet]
        public async Task<IActionResult> GetTransferencias()
        {
            var listaTrans = await _transRepo.GetTransferenciasAsync();
            var listaTransDto = _mapper.Map<List<TransferenciaDto>>(listaTrans);
            return Ok(listaTransDto);
        }

        // Obtenemos el id de dicha transferencia
        [HttpGet("{id}", Name = "GetTransferencia")]
        public async Task<IActionResult> GetTransferencia(int id)
        {
            var itemTrans = await _transRepo.GetTransferenciaAsync(id);
            if (itemTrans == null)
            {
                return NotFound();
            }
            var itemTransDto = _mapper.Map<TransferenciaDto>(itemTrans);
            return Ok(itemTransDto);
        }

        // POST de transferencia
        [HttpPost]
        public async Task<IActionResult> CrearTransferencia([FromBody] CreateTransferenciaDto createTransDto)
        {
            if (createTransDto == null)
            {
                return BadRequest(ModelState);
            }

            var transferencia = _mapper.Map<Transferencia>(createTransDto);

            if (!await _transRepo.CrearTransferenciaAsync(transferencia))
            {
                ModelState.AddModelError("", $"Algo salió mal enviando la transferencia a {transferencia.Destinatario}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetTransferencia", new { id = transferencia.Id }, transferencia);
        }
    }
}
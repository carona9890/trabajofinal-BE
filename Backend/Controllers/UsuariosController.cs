using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajoFinalBE.Data;
using TrabajoFinalBE.Dtos;
using TrabajoFinalBE.Models;

namespace TrabajoFinalBE.Controllers
{

    // Attribute routing para cada uno de los controllers
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST de usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(CreateUsuarioDto createDto)
        {
            var usuario = new Usuario
            {
                Nombre = createDto.Nombre,
                Email = createDto.Email,
                Password = createDto.Password
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // GET de usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
    }
}
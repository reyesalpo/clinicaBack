using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Hacemos referencia a la clase DbContext y se agrega el constructor
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista de usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios() 
        { 
            var usuario = await _context.Usuarios.ToListAsync();
            return Ok(usuario);
        }

        // Mostrar por usuario
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id) {

            var usuario = await _context.Usuarios.FindAsync(id);
            return Ok(usuario);
        }
    }
}

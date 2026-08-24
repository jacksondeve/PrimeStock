using Microsoft.AspNetCore.Mvc;
using PrimeStock.API.Services;
using PrimeStock.API.Models;

namespace PrimeStock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            var resultado = _usuarioService.CadastrarUsuario(usuario);
            return Ok(resultado);
        }

        [HttpPost("Login")]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioService.Login(email, senha);

            return Ok(usuario);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using PrimeStock.API.Services;
using PrimeStock.API.Models;
namespace PrimeStock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
       private readonly VendaService _vendaService;

        public VendaController(VendaService vendaService) 
        { 
            _vendaService = vendaService;
        }

        [HttpPost("cadastrar")]
        public ActionResult CadastrarVenda(Venda venda) 
        {
            var vendaCadastrada = _vendaService.CadastrarVenda(venda);
            return Ok(vendaCadastrada);
        }

        [HttpPost("Finalizar/{id}")]
        public IActionResult FinalizarVenda(int id) 
        {
            var resultado = _vendaService.FinalizarVenda(id);

            return Ok(resultado);
        }

        [HttpGet("consultar/{id}")]
        public IActionResult ConsultarVenda(int id) 
        {
            var venda = _vendaService.ConsultaVenda(id);

            if(venda == null) 
            {
                return NotFound("Venda não encontrada");
            }

            return Ok(venda);
        }
    }
}

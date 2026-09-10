
using Microsoft.AspNetCore.Mvc;
using PrimeStock.API.Services;
using PrimeStock.API.Models;

namespace PrimeStock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemVendaController : ControllerBase
    {
        private readonly ItemVendaService _itemVendaService;

        public ItemVendaController(ItemVendaService itemVendaService)
        {
            _itemVendaService = itemVendaService;
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarItemVenda(ItemVendaCadastroDTO itemVendaDTO)
        {
            var CadastroItemVenda = _itemVendaService.CadastrarItemVenda(itemVendaDTO);

            return Ok(CadastroItemVenda);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PrimeStock.API.Services;
using PrimeStock.API.Models;

namespace PrimeStock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost("cadastrar")]
        public ActionResult CadastrarProduto(Produto produto)
        {
            var cadastroproduto = _produtoService.CadastrarProduto(produto);
            return Ok(cadastroproduto);
        }


        [HttpGet("listar")]
        public ActionResult listarProdutos()
        {
            return Ok(_produtoService.ListarProdutos());
        }

        [HttpGet("buscar/{id}")]
        public ActionResult<Produto> BuscaProdutoporId(int id)
        {
            return Ok(_produtoService.BuscaProdutoporId(id));
        }

        [HttpPut("update/{id}")]
        public ActionResult<Produto> AtualizarProduto(int id, Produto produto)
        {
            return Ok(_produtoService.AtualizarProduto(id, produto ));
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<Produto> DeletarProduto(int id)
        {
            return Ok(_produtoService.DeletarProduto(id));
        }
    }

      
      
}
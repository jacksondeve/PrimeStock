using PrimeStock.API.Models;
using PrimeStock.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PrimeStock.API.Repositories
{
    public class ProdutoRepository
    {
        private readonly PrimeStockDbContext _context;

        public ProdutoRepository(PrimeStockDbContext context)
        {
            _context = context;
        }

        public List<Produto> listarProdutos()
        {
            return _context.Produtos.ToList();
        }

        public Produto listarProdutoporId(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public void CadastrarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public Produto AtualizarProduto(int id, Produto produto)
        {
            var produtoBanco = listarProdutoporId(id);

            if (produtoBanco != null)
            {
                produtoBanco.Nome = produto.Nome;
                produtoBanco.preco = produto.preco;
                produtoBanco.DataCadastro = produto.DataCadastro;
                produtoBanco.Descricao = produto.Descricao;
                produtoBanco.estoque = produto.estoque;

                _context.SaveChanges();

                return produtoBanco;
            }
            else 
            { 
                return null;
            }
        }

        public Produto DeletarporId(int Id)
        {
            var produto = listarProdutoporId(Id);

            if (produto != null)
            {
                _context.Produtos.Remove(produto);

                _context.SaveChanges();

                return produto;

            }
            else
            {
                return null;
            }
        }
    }
}

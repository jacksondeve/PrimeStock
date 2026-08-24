using PrimeStock.API.Repositories;
using PrimeStock.API.Models;

namespace PrimeStock.API.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _ProdutoRepository;
        public ProdutoService(ProdutoRepository produtoRepository) 
        {
            _ProdutoRepository = produtoRepository;
        }

        public string CadastrarProduto(Produto produto)
        {
            _ProdutoRepository.CadastrarProduto(produto);

            return "produto cadastrado com sucesso";
        }
        public List<Produto> ListarProdutos()
        {
            return _ProdutoRepository.listarProdutos();
        }

        public Produto  BuscaProdutoporId(int id)
        {
            return _ProdutoRepository.listarProdutoporId(id);
        }

        public Produto AtualizarProduto(int id, Produto produto) 
        {
            return _ProdutoRepository.AtualizarProduto(id, produto);
        }

        public Produto DeletarProduto(int id)
        {
            return _ProdutoRepository.DeletarporId(id);
        }

    }
}

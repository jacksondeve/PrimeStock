using PrimeStock.API.Repositories;
using PrimeStock.API.Models;
using System.Reflection.Metadata.Ecma335;
namespace PrimeStock.API.Services
{
    public class VendaService
    {
        private readonly VendaRepository _vendaRepository;
        private readonly ItemVendaRepository _itemVendaRepository;

        private readonly ProdutoRepository _produtoRepository;

        public VendaService(VendaRepository vendaRepository ,ItemVendaRepository itemVendaRepository, ProdutoRepository produtoRepository)
        {
            _vendaRepository = vendaRepository;
            _itemVendaRepository = itemVendaRepository;
            _produtoRepository = produtoRepository;
        }

        public string CadastrarVenda(Venda venda)
        {
            _vendaRepository.CadastrarVenda(venda);

            return "venda cadastrada com sucesso ";
        }

        public Venda BuscaVendaporId(int id) 
        {
            return _vendaRepository.BuscaVendaporId(id);
        }

        public List<ItemVenda> buscarItensDaVenda(int vendaId)
        {
            return _itemVendaRepository.BuscarItensPorVendaId(vendaId);
        }

        public List<ItemVenda> BuscaItensDaVenda(int vendaId)
        {
            return _itemVendaRepository.BuscarItensPorVendaId(vendaId);
        }

        public string  FinalizarVenda(int vendaId)
        {
            var venda = BuscaVendaporId(vendaId);

            if (venda == null)
            {
                return "venda nao encontrada";
            }


            var itensVenda = BuscaItensDaVenda(vendaId);

            if (itensVenda.Count == 0)
            {
                return "venda nao possui itens";
            }

            decimal total = 0;

            foreach (var item in itensVenda)
            {
                var produto = _produtoRepository.listarProdutoporId(item.ProdutoId);

                total = total + (item.Quantidade * item.PrecoUnitario);

                produto.estoque = produto.estoque - item.Quantidade;

                _produtoRepository.SalvarProduto(produto);
            }

            venda.ValorTotal = total;

            _vendaRepository.AtualizarVenda(venda);

            return "venda finalizzada com sucesso ";
        }

        

    }
}

using PrimeStock.API.Models;
using PrimeStock.API.Repositories;
using PrimeStock.API.Services;

namespace PrimeStock.API.Services
{
    public class ItemVendaService
    {
        private readonly ItemVendaRepository _itemVendaRepository;
        public readonly ProdutoRepository _ProdutoRepository;

        private readonly VendaRepository _VendaRepository;

        public ItemVendaService(ItemVendaRepository itemVendaRepository, ProdutoRepository produtoRepository, VendaRepository vendaRepository)
        {
            _itemVendaRepository = itemVendaRepository;
            _ProdutoRepository = produtoRepository;
            _VendaRepository = vendaRepository;

        }

        public string CadastrarItemVenda(ItemVendaCadastroDTO itemVendaDTO)
        {
            Console.WriteLine($"VendaId: {itemVendaDTO.VendaId}");
            Console.WriteLine($"ProdutoId: {itemVendaDTO.ProdutoId}");

            var venda = _VendaRepository.BuscaVendaporId(itemVendaDTO.VendaId);
            if(venda == null)
            {
                return "Venda não encontrada";
            }

            if (venda.Finalizada)
            {
                return "Venda ja finalizada";
            }
            var produto = _ProdutoRepository.listarProdutoporId(itemVendaDTO.ProdutoId);

            if (produto == null)
            {
                return "Produto nao Encontrado";
            }

            if(itemVendaDTO.Quantidade > produto.estoque)
            {
                return $"Produto possui apenas {produto.estoque} unidades disponiveis";
            }

            ItemVenda itemVenda = new ItemVenda
            {
                VendaId = itemVendaDTO.VendaId,
                ProdutoId = itemVendaDTO.ProdutoId,
                Quantidade = itemVendaDTO.Quantidade,
                PrecoUnitario = itemVendaDTO.PrecoUnitario
            };

            _itemVendaRepository.CadastroItemVenda(itemVenda);

            return "Venda cadastrada com sucesso";
        }
    }
}

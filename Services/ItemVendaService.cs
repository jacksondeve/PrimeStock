using PrimeStock.API.Models;
using PrimeStock.API.Repositories;
using PrimeStock.API.Services;

namespace PrimeStock.API.Services
{
    public class ItemVendaService
    {
        private readonly ItemVendaRepository _itemVendaRepository;
        public readonly ProdutoRepository _ProdutoRepository;

        public ItemVendaService(ItemVendaRepository itemVendaRepository, ProdutoRepository produtoRepository)
        {
            _itemVendaRepository = itemVendaRepository;
            _ProdutoRepository = produtoRepository;

        }

        public string CadastrarItemVenda(ItemVendaCadastroDTO itemVendaDTO)
        {
            Console.WriteLine($"VendaId: {itemVendaDTO.VendaId}");
            Console.WriteLine($"ProdutoId: {itemVendaDTO.ProdutoId}");
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

using PrimeStock.API.Repositories;
using PrimeStock.API.Models;
using System.Reflection.Metadata.Ecma335;
namespace PrimeStock.API.Services
{
    public class VendaService
    {
        private readonly VendaRepository _vendaRepository;
        private readonly ItemVendaRepository _itemVendaRepository;

        public VendaService(VendaRepository vendaRepository ,ItemVendaRepository itemVendaRepository)
        {
            _vendaRepository = vendaRepository;
            _itemVendaRepository = itemVendaRepository;        }

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
                total = total + (item.Quantidade * item.PrecoUnitario);
            }

            venda.ValorTotal = total;

            _vendaRepository.AtualizarVenda(venda);

            return "venda finalizzada com sucesso ";
        }

        

    }
}

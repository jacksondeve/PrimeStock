using PrimeStock.API.Repositories;
using PrimeStock.API.Models;
namespace PrimeStock.API.Services
{
    public class VendaService
    {
        private readonly VendaRepository _vendaRepository;

        public VendaService(VendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public string CadastrarVenda(Venda venda)
        {
            _vendaRepository.CadastrarVenda(venda);

            return "venda cadastrada com sucesso ";
        }

    }
}

using PrimeStock.API.Data;
using PrimeStock.API.Models;

namespace PrimeStock.API.Repositories
{
    public class VendaRepository
    {
        private readonly PrimeStockDbContext _context;

        public VendaRepository(PrimeStockDbContext context)
        {
            _context = context;
        }
        public void CadastrarVenda(Venda venda) 
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
        }
    }
}

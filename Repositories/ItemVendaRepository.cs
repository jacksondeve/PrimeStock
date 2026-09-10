using PrimeStock.API.Data;
using PrimeStock.API.Models;

namespace PrimeStock.API.Repositories
{
    public class ItemVendaRepository
    {
        private readonly PrimeStockDbContext _context ;

        public ItemVendaRepository( PrimeStockDbContext context)
        {
            _context = context ;
        }

        public void CadastroItemVenda(ItemVenda itemVenda)
        {
            _context.ItemVenda.Add(itemVenda);
            _context.SaveChanges();
        }


    }
}

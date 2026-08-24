using Microsoft.EntityFrameworkCore;
using PrimeStock.API.Models;
using PrimeStock.API.Data;

namespace PrimeStock.API.Data
{
    

    public class PrimeStockDbContext : DbContext
    {
        public PrimeStockDbContext(DbContextOptions<PrimeStockDbContext>options) : base (options) { }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Produto> Produtos {  get; set; }
    }
}


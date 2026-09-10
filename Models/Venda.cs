namespace PrimeStock.API.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public DateTime DataVenda {  get; set; }

        public decimal ValorTotal { get; set; }

        public List<ItemVenda> ItemVendas { get; set; } = new();

    }
}

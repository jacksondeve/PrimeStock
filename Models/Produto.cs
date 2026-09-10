namespace PrimeStock.API.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal preco { get; set; }

        public int estoque { get; set; }

        public DateTime DataCadastro { get; set; }

        public List<ItemVenda> ItemVendas { get; set; } = new();

    }
}
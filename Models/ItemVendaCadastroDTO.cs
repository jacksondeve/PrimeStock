namespace PrimeStock.API.Models
{
    public class ItemVendaCadastroDTO
    {
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}

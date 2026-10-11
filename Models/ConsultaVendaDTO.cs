
namespace PrimeStock.API.Models
{
    public class ConsultaVendaDTO
    {
        public int Id { get; set; }

        public DateTime DataVenda { get; set; }

        public decimal ValorTotal   { get; set; }

        public StatusVenda Status { get; set; }

        public List<ItemVendaConsultaDTO> Itens { get; set; }

    }
}


namespace FawryAPI.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public bool IsPaid { get; set; }
        public string? PaymentType { get; set; }
    }
}

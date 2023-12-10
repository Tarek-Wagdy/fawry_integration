using System.Text.Json.Serialization;

namespace FawryPayment.Models
{
    public class Invoice
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("cost")]
        public decimal Cost { get; set; }
        [JsonPropertyName("quantity")]
        public decimal Quentity { get; set; }
        [JsonPropertyName("isPaid")]
        public bool IsPaid { get; set; }
        [JsonPropertyName("paymentType")]
        public string PaymentType { get; set; }
    }
}

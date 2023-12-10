using System.Text.Json.Serialization;

namespace FawryPayment.Models
{
    public class Client
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("mobile")]
        public string Mobile { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}

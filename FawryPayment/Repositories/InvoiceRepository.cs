using FawryPayment.Interfaces;
using FawryPayment.Models;
using System.Text.Json;

namespace FawryPayment.Repositories
{
    public class InvoiceRepository:Iinvoice
    {
        private readonly HttpClient httpClient;

        public InvoiceRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Invoice>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<List<Invoice>>(
               await httpClient.GetStreamAsync($"api/Invoice"));
        }
    }
}

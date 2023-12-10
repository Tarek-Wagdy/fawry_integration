using FawryPayment.Interfaces;
using FawryPayment.Models;
using System.Text.Json;

namespace FawryPayment.Repositories
{
    public class ClientRepository:IClient
    {
        private readonly HttpClient httpClient;

        public ClientRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Client>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<List<Client>>(
               await httpClient.GetStreamAsync($"api/Client"));
        }
    }
}

using FawryPayment.Interfaces;
using FawryPayment.Models;
using System.Text;
using System.Text.Json;

namespace FawryPayment.Repositories
{
    public class FawryPaymentRepository : IFawryPayment
    {
        public HttpClient _HttpClient;
        public FawryPaymentRepository(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task PayInvoiceWithCard(int invoiceId)
        {
          
            var apiUrl = $"api/FawryPayment/PayWithCard?invoiceId={invoiceId}";
            await _HttpClient.PostAsync(apiUrl, null);
        }

        public async Task PayInvoiceWithMWallet(int invoiceId)
        {
            var apiUrl = $"api/FawryPayment/PayWithWallet?invoiceId={invoiceId}";
            await _HttpClient.PostAsync(apiUrl, null);
        }
    }
}

using FawryPayment.Interfaces;
using FawryPayment.Models;
using Microsoft.AspNetCore.Components;

namespace FawryPayment.Pages
{
    public partial class InvoiceData
    {
       public List<Invoice> invoices;
        public int v1;
        public string v2;
        [Inject]
        public Iinvoice _invoice { get; set; }
        [Inject]
        public IFawryPayment _fawryPayment { get; set; }
        protected override async Task OnInitializedAsync()
        {
            invoices =await _invoice.GetAll();
        }
        public async Task payWithCard(int InvoiceId)
        {
           await _fawryPayment.PayInvoiceWithCard(InvoiceId);
            invoices = await _invoice.GetAll();
        }
        public async Task payWithWallet(int InvoiceId)
        {
            await _fawryPayment.PayInvoiceWithMWallet(InvoiceId);
            invoices = await _invoice.GetAll();
        }
    }
}

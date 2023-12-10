using FawryPayment.Models;

namespace FawryPayment.Interfaces
{
    public interface IFawryPayment
    {
        Task PayInvoiceWithCard(int invoiceId);
        Task PayInvoiceWithMWallet(int invoiceId);
    }
}

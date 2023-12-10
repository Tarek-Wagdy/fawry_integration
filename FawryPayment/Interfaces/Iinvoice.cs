using FawryPayment.Models;

namespace FawryPayment.Interfaces
{
    public interface Iinvoice
    {
        Task< List<Invoice>> GetAll();
    }
}

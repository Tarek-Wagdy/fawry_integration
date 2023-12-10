using FawryPayment.Models;

namespace FawryPayment.Interfaces
{
    public interface IClient
    {
        Task< List<Client>> GetAll();
    }
}

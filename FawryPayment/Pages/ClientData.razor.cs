using FawryPayment.Interfaces;
using FawryPayment.Models;
using Microsoft.AspNetCore.Components;

namespace FawryPayment.Pages
{
    public partial class ClientData
    {
        public List<Client> Clients;
        [Inject]
        public IClient _Client { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Clients =await _Client.GetAll();
        }

    }
}

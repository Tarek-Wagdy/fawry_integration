using FawryPayment;
using FawryPayment.Interfaces;
using FawryPayment.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
namespace FawryPayment
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient<IFawryPayment, FawryPaymentRepository>(client =>
            client.BaseAddress=new Uri("https://localhost:44356/")
            );
            builder.Services.AddHttpClient<IClient, ClientRepository>(client =>
            client.BaseAddress = new Uri("https://localhost:44356/")
            );
            builder.Services.AddHttpClient<Iinvoice, InvoiceRepository>(client =>
            client.BaseAddress = new Uri("https://localhost:44356/")
            );
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
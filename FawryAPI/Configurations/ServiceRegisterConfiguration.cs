

using FawryAPI.Repositories;

namespace FawryAPI.Settings.Configurations
{
    public static class ServiceRegisterConfiguration
    {
        public static IServiceCollection AddServicesRegister(this IServiceCollection services)
        {
            services.AddScoped<IFawryWalletPayment, FawryWalletPaymentRepository>();
            services.AddScoped<IFawryCardPayment, FawryCardPaymentRepository>();
            services.AddScoped(typeof(IGeneric<>), typeof(GenericRepository<>));
            return services;
        }
    }
}

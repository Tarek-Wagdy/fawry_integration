namespace FawryAPI.Middlewares;

public static class HandleExceptionsGlobally
{
    public static IServiceCollection CustomMiddlewareRegistering(this IServiceCollection services)
    {
        services.AddTransient<ErrorHandlerMiddleware>();
        return services;
    }
    public static void ConfigureCustomeExceptionMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}

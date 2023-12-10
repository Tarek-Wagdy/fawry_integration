namespace FawryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var configuration = builder.Configuration;
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.CustomMiddlewareRegistering();
            builder.Services.AddServicesRegister();
            builder.Services.AddDbContext<ApplicationContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("DbConnection"))
            ) ;
            builder.Services.AddCors(options =>
            options.AddPolicy("myPolicy", builder =>
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.ConfigureCustomeExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseCors("myPolicy");
            app.UseRouting();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
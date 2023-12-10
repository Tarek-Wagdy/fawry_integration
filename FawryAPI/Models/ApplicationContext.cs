

namespace FawryAPI.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
                
        }
        public DbSet<Client> clients { get; set; }
        public DbSet<Invoice> invoices { get; set; }
    }
}

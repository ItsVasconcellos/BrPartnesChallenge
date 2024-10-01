using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Domain.Entities.Client> Clients { get; set; }
        public DbSet<Domain.Entities.Address> Address { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Domain.Entities.Client> Clients { get; set; }
    }
}

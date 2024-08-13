using Microsoft.EntityFrameworkCore;
namespace Staff_Management.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Departments> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
    }
}

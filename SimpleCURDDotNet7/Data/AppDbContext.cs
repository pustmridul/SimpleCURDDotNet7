using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleCURDDotNet7.Data
{
        public class AppDbContext : DbContext
        {

            public AppDbContext(DbContextOptions options)
                : base(options)
            {
            }

            public DbSet<Product> Products { get; set; }
            public DbSet<Employee> Employees { get; set; }

        }
        public class BloggingContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=123;Database=ProductDb;");


                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }

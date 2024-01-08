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
        }
        public class BloggingContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456;Database=ProductDb;");


                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }

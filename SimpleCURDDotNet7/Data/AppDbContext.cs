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

            public DbSet<UserInfo> UserInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasData(new UserInfo
            {
                Id = 1,
                UserName = "test",
                Password = "1234",
                CreateByName = "System",
                CreateDate = DateTime.UtcNow
            });

         }

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

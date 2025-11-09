using BookStore.Ordering.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Ordering.Domain
{
    public sealed class OrderingDbContext:DbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options) : base(options)
        {
           /* if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();
            }*/
        }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<BasketEntity> Baskets { get; set; }
        public DbSet<BasketItemEntity> BasketItems { get; set; }
        public DbSet<OrderingEntity> Orders { get; set; }
    }
    public static class ConnectionExtension
    {
        public static WebApplicationBuilder AddData(this WebApplicationBuilder builder)
        {
            /* services.AddDbContext<UserContext>(options => options.UseSqlServer(
     "Data Source=.\\SQLEXPRESS; Database=UserBase; Persist Security Info=False; MultipleActiveResultSets=True; Trusted_Connection=True;"
     ));*/

            builder.Services.AddDbContext<OrderingDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Ordering")));

            return builder;
        }
    }
}

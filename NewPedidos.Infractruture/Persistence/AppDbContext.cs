using Microsoft.EntityFrameworkCore;
using NewPedidos.Core.Entities;


namespace NewPedidos.Infractruture.Persistence
{
   
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
    }
}

using Microsoft.EntityFrameworkCore;
using NewPedidos.Core.Entities;


namespace NewPedidos.Infractruture.Persistence
{
   
    public class AppDbContext: DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");

        /*
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
                 

            builder
                .Entity<Order>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasMany(p => p.Products)
                        .WithOne(p => p.Order)
                        .HasForeignKey(p => p.IdOrder)
                        .OnDelete(DeleteBehavior.Restrict);

                });

            
            builder
                .Entity<Product>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasOne(p => p.Order)
                        .WithMany(f => f.Products)
                        .HasForeignKey(p => p.IdOrder)
                        .OnDelete(DeleteBehavior.Restrict);

                    
                });

            base.OnModelCreating(builder); 
        
    }
        */

    }

}

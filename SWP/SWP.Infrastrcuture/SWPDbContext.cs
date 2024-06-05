using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SWP.Infrastrcuture.Entities;

namespace SWP.Infrastrcuture
{
    public class SWPDbContext : IdentityDbContext<AppUser>
    {
        public SWPDbContext(DbContextOptions<SWPDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MilkBrand>().Navigation(c => c.Company).AutoInclude();

            base.OnModelCreating(builder);
            builder.Entity<Company>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<MilkBrand>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Product>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ProductItem>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<MilkFunction>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<MilkBrandFunction>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Nutrient>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ProductNutrient>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Order>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<OrderDetail>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Payment>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Image>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<MilkBrand> MilkBrands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<MilkFunction> MilkFunctions { get; set; }
        public DbSet<MilkBrandFunction> MilkBrandFunctions { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<ProductNutrient> ProductNutrients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Image> Images { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                }else if(entry.State == EntityState.Modified)
                {
                    entity.UpdatedDate = now;
                }

                
            }
        }
    }
}

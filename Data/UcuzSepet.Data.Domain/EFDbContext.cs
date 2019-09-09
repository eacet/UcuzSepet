using Microsoft.EntityFrameworkCore;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Data.Domain {
    public class EFDbContext : DbContext {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

        }
    }
}

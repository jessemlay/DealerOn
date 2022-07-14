using Microsoft.EntityFrameworkCore;

namespace DealerOn.Web.Models
{
    public class DealerOnContext: DbContext
    {
        public DbSet<Product> Products { get; set; }   
        public DbSet<Category> Categories { get; set; }

        public DealerOnContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Put this in to convert the enum category to string in the db
            modelBuilder.Entity<Category>()
                .Property(u => u.Name)
                .HasConversion<string>()
                .HasMaxLength(50);
        }
    }
}

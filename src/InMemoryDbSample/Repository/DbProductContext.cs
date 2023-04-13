using InMemoryDbSample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InMemoryDbSample.Repository
{
    public class DbProductContext : DbContext
    {
        public DbProductContext(DbContextOptions<DbProductContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());                        
        }
    }

    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(c => c.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(200)");
            
        }
    }
}

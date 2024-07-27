using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Catalog.Domain.Products;

namespace Shop.Catalog.Infrastructure.Configuration
{
    public class ProductRepositoryConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Catalog");

            builder.HasKey(p => p.ID);

            builder.Property(p => p.ID).ValueGeneratedNever();

            builder.Property(p => p.Name).IsRequired().IsUnicode().HasMaxLength(100);

            builder.Property(p => p.Price).IsRequired().HasPrecision(8, 0);

            builder.Property(p => p.Description).IsRequired(false).IsUnicode().HasMaxLength(250);
        }
    }
}

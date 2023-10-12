using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class ProductsPricesMap : IEntityTypeConfiguration<ProductsPrices>
    {
        public void Configure(EntityTypeBuilder<ProductsPrices> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("products_prices", "public");

            // key
            builder.HasKey(t => t.id);

            // properties
            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("text");

            builder.Property(t => t.weight)
                .IsRequired()
                .HasColumnName("weight")
                .HasColumnType("numeric(18,2)");

            builder.Property(t => t.price)
                .IsRequired()
                .HasColumnName("price")
                .HasColumnType("numeric(18,2)");

            builder.Property(t => t.price_sale)
                .HasColumnName("price_sale")
                .HasColumnType("numeric(18,2)")
                .HasDefaultValueSql("0");

            builder.Property(t => t.product_id)
                .IsRequired()
                .HasColumnName("product_id")
                .HasColumnType("text");

            // relationships
            builder.HasOne(t => t.product_Products)
                .WithMany(t => t.product_ProductsPrices)
                .HasForeignKey(d => d.product_id)
                .HasConstraintName("fk_products_prices_products");

            #endregion
        }
    }
}

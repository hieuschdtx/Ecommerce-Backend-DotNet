using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class ProductsMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("products", "public");

            // key
            builder.HasKey(t => t.id);

            // properties
            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("text");

            builder.Property(t => t.name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.alias)
                .IsRequired()
                .HasColumnName("alias")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.product_category_id)
                .IsRequired()
                .HasColumnName("product_category_id")
                .HasColumnType("text");

            // relationships
            builder.HasOne(t => t.product_category_ProductCategories)
                .WithMany(t => t.product_category_Products)
                .HasForeignKey(d => d.product_category_id)
                .HasConstraintName("fk_product_category");

            #endregion
        }
    }
}

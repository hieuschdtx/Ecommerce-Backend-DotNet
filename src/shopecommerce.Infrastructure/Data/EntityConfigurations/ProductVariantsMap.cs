using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class ProductVariantsMap : IEntityTypeConfiguration<ProductVariants>
    {
        public void Configure(EntityTypeBuilder<ProductVariants> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("product_variants", "public");

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

            builder.Property(t => t.product_id)
                .IsRequired()
                .HasColumnName("product_id")
                .HasColumnType("text");

            // relationships
            builder.HasOne(t => t.product_Products)
                .WithMany(t => t.product_ProductVariants)
                .HasForeignKey(d => d.product_id)
                .HasConstraintName("fk_productvariants_product");

            #endregion
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class ProductColorsMap : IEntityTypeConfiguration<ProductColors>
    {
        public void Configure(EntityTypeBuilder<ProductColors> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("product_colors", "public");

            // key
            builder.HasKey(t => t.id);

            // properties
            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("text");

            builder.Property(t => t.product_id)
                .HasColumnName("product_id")
                .HasColumnType("text");

            builder.Property(t => t.color_id)
                .HasColumnName("color_id")
                .HasColumnType("text");

            builder.Property(t => t.avatar_color)
                .HasColumnName("avatar_color")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            // relationships
            builder.HasOne(t => t.product_Products)
                .WithMany(t => t.product_ProductColors)
                .HasForeignKey(d => d.product_id)
                .HasConstraintName("fk_productcolor_product");

            builder.HasOne(t => t.color_Colors)
                .WithMany(t => t.color_ProductColors)
                .HasForeignKey(d => d.color_id)
                .HasConstraintName("fk_productcolor_color");

            #endregion
        }
    }
}

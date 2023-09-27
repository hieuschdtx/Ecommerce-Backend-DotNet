using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class ProductDetailsMap : IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("product_details", "public");

            // key
            builder.HasKey(t => t.id);

            // properties
            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("text");

            builder.Property(t => t.description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder.Property(t => t.detail)
                .HasColumnName("detail")
                .HasColumnType("text");

            builder.Property(t => t.avatar)
                .HasColumnName("avatar")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.thumnails)
                .HasColumnName("thumnails")
                .HasColumnType("json");

            builder.Property(t => t.status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("boolean");

            builder.Property(t => t.home_flag)
                .IsRequired()
                .HasColumnName("home_flag")
                .HasColumnType("boolean");

            builder.Property(t => t.hot_flag)
                .IsRequired()
                .HasColumnName("hot_flag")
                .HasColumnType("boolean");

            builder.Property(t => t.memory)
                .HasColumnName("memory")
                .HasColumnType("integer");

            builder.Property(t => t.price)
                .HasColumnName("price")
                .HasColumnType("numeric(18,0)");

            builder.Property(t => t.stock)
                .IsRequired()
                .HasColumnName("stock")
                .HasColumnType("bigint");

            builder.Property(t => t.view_count)
                .HasColumnName("view_count")
                .HasColumnType("bigint");

            builder.Property(t => t.create_by)
                .HasColumnName("create_by")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.create_at)
                .IsRequired()
                .HasColumnName("create_at")
                .HasColumnType("timestamp without time zone");

            builder.Property(t => t.modified_by)
                .HasColumnName("modified_by")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.modified_at)
                .HasColumnName("modified_at")
                .HasColumnType("timestamp without time zone");

            builder.Property(t => t.product_id)
                .HasColumnName("product_id")
                .HasColumnType("text");

            builder.Property(t => t.productvariant_id)
                .HasColumnName("productvariant_id")
                .HasColumnType("text");

            builder.Property(t => t.promotion_id)
                .HasColumnName("promotion_id")
                .HasColumnType("text");

            builder.Property(t => t.producttag_id)
                .HasColumnName("producttag_id")
                .HasColumnType("text");

            // relationships
            builder.HasOne(t => t.product_Products)
                .WithMany(t => t.product_ProductDetails)
                .HasForeignKey(d => d.product_id)
                .HasConstraintName("fk_productdetail_product");

            builder.HasOne(t => t.productvariant_ProductVariants)
                .WithMany(t => t.productvariant_ProductDetails)
                .HasForeignKey(d => d.productvariant_id)
                .HasConstraintName("fk_productdetail_productvariant");

            builder.HasOne(t => t.promotion_Promotions)
                .WithMany(t => t.promotion_ProductDetails)
                .HasForeignKey(d => d.promotion_id)
                .HasConstraintName("fk_productdetail_promotion");

            builder.HasOne(t => t.producttag_ProductTags)
                .WithMany(t => t.producttag_ProductDetails)
                .HasForeignKey(d => d.producttag_id)
                .HasConstraintName("fk_productdetail_producttag");

            #endregion
        }
    }
}

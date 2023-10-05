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
                .HasColumnType("text");

            builder.Property(t => t.description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder.Property(t => t.detail)
                .HasColumnName("detail")
                .HasColumnType("text");

            builder.Property(t => t.alias)
                .IsRequired()
                .HasColumnName("alias")
                .HasColumnType("text");

            builder.Property(t => t.avatar)
                .HasColumnName("avatar")
                .HasColumnType("text");

            builder.Property(t => t.thumnails)
                .HasColumnName("thumnails")
                .HasColumnType("json");

            builder.Property(t => t.status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("boolean")
                .HasDefaultValueSql("true");

            builder.Property(t => t.home_flag)
                .IsRequired()
                .HasColumnName("home_flag")
                .HasColumnType("boolean")
                .HasDefaultValueSql("true");

            builder.Property(t => t.hot_flag)
                .IsRequired()
                .HasColumnName("hot_flag")
                .HasColumnType("boolean");

            builder.Property(t => t.stock)
                .IsRequired()
                .HasColumnName("stock")
                .HasColumnType("integer");

            builder.Property(t => t.view_count)
                .HasColumnName("view_count")
                .HasColumnType("integer")
                .HasDefaultValueSql("0");

            builder.Property(t => t.created_by)
                .HasColumnName("created_by")
                .HasColumnType("text");

            builder.Property(t => t.created_at)
                .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()");

            builder.Property(t => t.modified_by)
                .HasColumnName("modified_by")
                .HasColumnType("text");

            builder.Property(t => t.modified_at)
                .HasColumnName("modified_at")
                .HasColumnType("timestamp without time zone");

            builder.Property(t => t.product_category_id)
                .IsRequired()
                .HasColumnName("product_category_id")
                .HasColumnType("text");

            builder.Property(t => t.promotion_id)
                .HasColumnName("promotion_id")
                .HasColumnType("text");

            builder.Property(t => t.origin)
                .HasColumnName("origin")
                .HasColumnType("text");

            builder.Property(t => t.storage)
                .HasColumnName("storage")
                .HasColumnType("text");

            // relationships
            builder.HasOne(t => t.product_category_ProductCategories)
                .WithMany(t => t.product_category_Products)
                .HasForeignKey(d => d.product_category_id)
                .HasConstraintName("fk_product_category");

            builder.HasOne(t => t.promotion_Promotions)
                .WithMany(t => t.promotion_Products)
                .HasForeignKey(d => d.promotion_id)
                .HasConstraintName("fk_product_promotion");

            #endregion
        }
    }
}

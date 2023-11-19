using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class ProductCategoriesMap : IEntityTypeConfiguration<ProductCategories>
    {
        public void Configure(EntityTypeBuilder<ProductCategories> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("product_categories", "public");

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

            builder.Property(t => t.alias)
                .IsRequired()
                .HasColumnName("alias")
                .HasColumnType("text");

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

            builder.Property(t => t.category_id)
                .IsRequired()
                .HasColumnName("category_id")
                .HasColumnType("text");

            builder.Property(t => t.promotion_id)
                .HasColumnName("promotion_id")
                .HasColumnType("text");

            builder.Property(t => t.display_order)
                .IsRequired()
                .HasColumnName("display_order")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            // relationships
            builder.HasOne(t => t.category_Categories)
                .WithMany(t => t.category_ProductCategories)
                .HasForeignKey(d => d.category_id)
                .HasConstraintName("fk_productcategory_category");

            builder.HasOne(t => t.promotion_Promotions)
                .WithMany(t => t.promotion_ProductCategories)
                .HasForeignKey(d => d.promotion_id)
                .HasConstraintName("fk_productcategory_promotion");
            #endregion
        }
    }
}

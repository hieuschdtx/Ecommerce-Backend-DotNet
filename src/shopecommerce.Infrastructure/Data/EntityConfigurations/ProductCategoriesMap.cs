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
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.description)
                .HasColumnName("description")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.alias)
                .IsRequired()
                .HasColumnName("alias")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

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

            builder.Property(t => t.category_id)
                .HasColumnName("category_id")
                .HasColumnType("text");

            builder.Property(t => t.promotion_id)
                .HasColumnName("promotion_id")
                .HasColumnType("text");

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

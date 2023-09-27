using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class ProductTagsMap : IEntityTypeConfiguration<ProductTags>
    {
        public void Configure(EntityTypeBuilder<ProductTags> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("product_tags", "public");

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

            builder.Property(t => t.url)
                .HasColumnName("url")
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

            // relationships

            #endregion
        }
    }
}

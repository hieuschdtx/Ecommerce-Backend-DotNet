using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class SlidesMap : IEntityTypeConfiguration<Slides>
    {
        public void Configure(EntityTypeBuilder<Slides> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("slides", "public");

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

            builder.Property(t => t.image)
                .HasColumnName("image")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.url)
                .HasColumnName("url")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.display_order)
                .HasColumnName("display_order")
                .HasColumnType("integer");

            builder.Property(t => t.status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("boolean");

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

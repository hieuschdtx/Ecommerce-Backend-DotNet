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
                .HasColumnType("text");

            builder.Property(t => t.image)
                .HasColumnName("image")
                .HasColumnType("text");

            builder.Property(t => t.url)
                .HasColumnName("url")
                .HasColumnType("text");

            builder.Property(t => t.status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("boolean")
                .HasDefaultValueSql("true");

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

            builder.Property(t => t.display_order)
                .IsRequired()
                .HasColumnName("display_order")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            // relationships
            #endregion
        }
    }
}

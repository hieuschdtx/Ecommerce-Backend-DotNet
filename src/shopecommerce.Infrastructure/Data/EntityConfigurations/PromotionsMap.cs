using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class PromotionsMap : IEntityTypeConfiguration<Promotions>
    {
        public void Configure(EntityTypeBuilder<Promotions> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("promotions", "public");

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

            builder.Property(t => t.discount)
                .IsRequired()
                .HasColumnName("discount")
                .HasColumnType("integer");

            builder.Property(t => t.from_day)
                .IsRequired()
                .HasColumnName("from_day")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()");

            builder.Property(t => t.to_day)
                .IsRequired()
                .HasColumnName("to_day")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()");

            builder.Property(t => t.status)
                .HasColumnName("status")
                .HasColumnType("boolean")
                .HasDefaultValueSql("false");

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

            // relationships
            #endregion
        }
    }
}

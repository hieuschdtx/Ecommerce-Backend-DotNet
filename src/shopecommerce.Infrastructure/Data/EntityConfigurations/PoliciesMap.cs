using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class PoliciesMap : IEntityTypeConfiguration<Policies>
    {
        public void Configure(EntityTypeBuilder<Policies> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("policies", "public");

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

            builder.Property(t => t.detail)
                .HasColumnName("detail")
                .HasColumnType("text");

            builder.Property(t => t.alias)
                .IsRequired()
                .HasColumnName("alias")
                .HasColumnType("text");

            builder.Property(t => t.created_by)
                .HasColumnName("create_by")
                .HasColumnType("text");

            builder.Property(t => t.created_at)
                .IsRequired()
                .HasColumnName("create_at")
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

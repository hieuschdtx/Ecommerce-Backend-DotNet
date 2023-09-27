using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class RolesMap : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("roles", "public");

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

            builder.Property(t => t.name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("text");

            builder.Property(t => t.normalize_name)
                .HasColumnName("normalize_name")
                .HasColumnType("text");

            builder.Property(t => t.concurrency_stamp)
                .HasColumnName("concurrency_stamp")
                .HasColumnType("text");

            // relationships
            #endregion
        }
    }
}

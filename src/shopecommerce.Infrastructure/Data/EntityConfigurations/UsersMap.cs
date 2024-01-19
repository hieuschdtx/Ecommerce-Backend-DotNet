using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class UsersMap
        : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("users", "public");

            // key
            builder.HasKey(t => t.id);

            // properties
            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("text");

            builder.Property(t => t.full_name)
                .IsRequired()
                .HasColumnName("full_name")
                .HasColumnType("text");

            builder.Property(t => t.address)
                .HasColumnName("address")
                .HasColumnType("text");

            builder.Property(t => t.avatar)
                .HasColumnName("avatar")
                .HasColumnType("text");

            builder.Property(t => t.dob)
                .HasColumnName("dob")
                .HasColumnType("date");

            builder.Property(t => t.refresh_token)
                .HasColumnName("refresh_token")
                .HasColumnType("text");

            builder.Property(t => t.gender)
                .HasColumnName("gender")
                .HasColumnType("boolean")
                .HasDefaultValueSql("false");

            builder.Property(t => t.email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("text");

            builder.Property(t => t.email_confirmed)
                .HasColumnName("email_confirmed")
                .HasColumnType("boolean")
                .HasDefaultValueSql("false");

            builder.Property(t => t.password)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("text");

            builder.Property(t => t.phone_number)
                .IsRequired()
                .HasColumnName("phone_number")
                .HasColumnType("text");

            builder.Property(t => t.phone_number_confirmed)
                .HasColumnName("phone_number_confirmed")
                .HasColumnType("boolean")
                .HasDefaultValueSql("false");

            builder.Property(t => t.lockout_end)
                .HasColumnName("lockout_end")
                .HasColumnType("timestamp without time zone");

            builder.Property(t => t.access_failed_count)
                .HasColumnName("access_failed_count")
                .HasColumnType("integer")
                .HasDefaultValueSql("0");

            builder.Property(t => t.created_at)
                .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()");

            builder.Property(t => t.modified_at)
                .HasColumnName("modified_at")
                .HasColumnType("timestamp without time zone");

            builder.Property(t => t.role_id)
                .IsRequired()
                .HasColumnName("role_id")
                .HasColumnType("text");

            builder.Property(t => t.verify_code)
                .HasColumnName("verify_code")
                .HasColumnType("text");

            builder.Property(t => t.verify_time_exp)
                .HasColumnName("verify_time_exp")
                .HasColumnType("numeric(19,0)")
                .HasDefaultValueSql("0");

            // relationships
            builder.HasOne(t => t.role_Roles)
                .WithMany(t => t.role_Users)
                .HasForeignKey(d => d.role_id)
                .HasConstraintName("fk_users_role");

            #endregion
        }
    }
}

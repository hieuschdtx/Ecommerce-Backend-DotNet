using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class OrdersMap : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("orders", "public");

            // key
            builder.HasKey(t => t.id);

            // properties
            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("text");

            builder.Property(t => t.customer_name)
                .IsRequired()
                .HasColumnName("customer_name")
                .HasColumnType("text");

            builder.Property(t => t.code)
               .IsRequired()
               .HasColumnName("code")
               .HasColumnType("text");

            builder.Property(t => t.customer_address)
                .IsRequired()
                .HasColumnName("customer_address")
                .HasColumnType("text");

            builder.Property(t => t.customer_email)
                .IsRequired()
                .HasColumnName("customer_email")
                .HasColumnType("text");

            builder.Property(t => t.customer_phone)
                .IsRequired()
                .HasColumnName("customer_phone")
                .HasColumnType("text");

            builder.Property(t => t.note)
                .HasColumnName("note")
                .HasColumnType("text");

            builder.Property(t => t.request_invoice)
                .IsRequired()
                .HasColumnName("request_invoice")
                .HasColumnType("boolean");

            builder.Property(t => t.delivery_date)
                .IsRequired()
                .HasColumnName("delivery_date")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()");

            builder.Property(t => t.created_at)
                .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()");

            builder.Property(t => t.bill_invoice)
                .IsRequired()
                .HasColumnName("bill_invoice")
                .HasColumnType("numeric(18,2)");

            builder.Property(t => t.is_vat)
                .IsRequired()
                .HasColumnName("is_vat")
                .HasColumnType("boolean");

            builder.Property(t => t.user_id)
                .HasColumnName("user_id")
                .HasColumnType("text");

            builder.Property(t => t.status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("boolean");

            builder.Property(t => t.status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("integer")
                .HasDefaultValueSql("1");

            builder.Property(t => t.payment_methods_id)
                .IsRequired()
                .HasColumnName("payment_methods_id")
                .HasColumnType("integer")
                .HasDefaultValueSql("1");

            // relationships
            builder.HasOne(t => t.user_Users)
                .WithMany(t => t.user_Orders)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("fk_order_user");

            builder.HasOne(t => t.payment_methods_PaymentMethods)
                .WithMany(t => t.payment_methods_Orders)
                .HasForeignKey(d => d.payment_methods_id)
                .HasConstraintName("fk_orders_payment_methods");

            #endregion
        }
    }
}

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
                .HasColumnType("date")
                .HasDefaultValueSql("now()");

            builder.Property(t => t.create_at)
                .IsRequired()
                .HasColumnName("create_at")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()");

            builder.Property(t => t.payment_status)
                .HasColumnName("payment_status")
                .HasColumnType("text");

            builder.Property(t => t.status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("text")
                .HasDefaultValueSql("false");

            builder.Property(t => t.bill_invoice)
                .IsRequired()
                .HasColumnName("bill_invoice")
                .HasColumnType("numeric(18,0)");

            builder.Property(t => t.payment_method_id)
                .IsRequired()
                .HasColumnName("payment_method_id")
                .HasColumnType("text");

            builder.Property(t => t.user_id)
                .HasColumnName("user_id")
                .HasColumnType("text");

            // relationships
            builder.HasOne(t => t.payment_method_PaymentMethods)
                .WithMany(t => t.payment_method_Orders)
                .HasForeignKey(d => d.payment_method_id)
                .HasConstraintName("fk_order_paymentmethod");

            builder.HasOne(t => t.user_Users)
                .WithMany(t => t.user_Orders)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("fk_order_user");

            #endregion
        }
    }
}

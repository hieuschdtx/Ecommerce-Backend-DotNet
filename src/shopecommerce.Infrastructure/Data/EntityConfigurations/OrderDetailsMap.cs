using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class OrderDetailsMap : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("order_details", "public");

            // key
            builder.HasKey(t => t.id);

            // properties
            builder.Property(t => t.product_id)
                .IsRequired()
                .HasColumnName("product_id")
                .HasColumnType("text");

            builder.Property(t => t.order_id)
                .IsRequired()
                .HasColumnName("order_id")
                .HasColumnType("text");

            builder.Property(t => t.quantity)
                .IsRequired()
                .HasColumnName("quantity")
                .HasColumnType("integer");

            builder.Property(t => t.total_amount)
                .IsRequired()
                .HasColumnName("total_amount")
                .HasColumnType("numeric(18,2)");

            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("text");

            // relationships
            builder.HasOne(t => t.product_Products)
                .WithMany(t => t.product_OrderDetails)
                .HasForeignKey(d => d.product_id)
                .HasConstraintName("fk_orderdetail_product");

            builder.HasOne(t => t.order_Orders)
                .WithMany(t => t.order_OrderDetails)
                .HasForeignKey(d => d.order_id)
                .HasConstraintName("fk_orderdetail_order");

            #endregion
        }
    }
}

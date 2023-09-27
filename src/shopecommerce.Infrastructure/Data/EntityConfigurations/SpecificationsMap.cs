using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Infrastructure.Data.EntityConfigurations
{
    public class SpecificationsMap
        : IEntityTypeConfiguration<Specifications>
    {
        public void Configure(EntityTypeBuilder<Specifications> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("specifications", "public");

            // key
            builder.HasKey(t => t.id);

            // properties
            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("text");

            builder.Property(t => t.screen_size)
                .HasColumnName("screen_size")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.screen_technology)
                .HasColumnName("screen_technology")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.refresh_rate)
                .HasColumnName("refresh_rate")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.chipset)
                .HasColumnName("chipset")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.gpu)
                .HasColumnName("gpu")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.internal_memory)
                .HasColumnName("internal_memory")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.operating_system)
                .HasColumnName("operating_system")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.rear_camera)
                .HasColumnName("rear_camera")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.bluetooth)
                .HasColumnName("bluetooth")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.battery_capacity)
                .HasColumnName("battery_capacity")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.frame_material)
                .HasColumnName("frame_material")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.back_material)
                .HasColumnName("back_material")
                .HasColumnType("character varying(256)")
                .HasMaxLength(256);

            builder.Property(t => t.dual_sim)
                .HasColumnName("dual_sim")
                .HasColumnType("boolean");

            builder.Property(t => t.hd_voice)
                .HasColumnName("hd_voice")
                .HasColumnType("boolean");

            builder.Property(t => t.volte)
                .HasColumnName("volte")
                .HasColumnType("boolean");

            builder.Property(t => t.product_id)
                .HasColumnName("product_id")
                .HasColumnType("text");

            builder.Property(t => t.productvariant_id)
                .HasColumnName("productvariant_id")
                .HasColumnType("text");

            // relationships
            builder.HasOne(t => t.product_Products)
                .WithMany(t => t.product_Specifications)
                .HasForeignKey(d => d.product_id)
                .HasConstraintName("fk_specification_product");

            builder.HasOne(t => t.productvariant_ProductVariants)
                .WithMany(t => t.productvariant_Specifications)
                .HasForeignKey(d => d.productvariant_id)
                .HasConstraintName("fk_specification_productvariant");

            #endregion
        }
    }
}

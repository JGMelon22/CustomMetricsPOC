using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomMetricsPOC.Models;

namespace CustomMetricsPOC.Infrastructure.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(o => o.Id)
            .HasName("pk_order");

        builder.HasIndex(o => o.Id)
            .HasDatabaseName("idx_order_id");

        builder.Property(o => o.Id)
            .HasColumnType("INTEGER")
            .HasColumnName("order_id")
            .ValueGeneratedOnAdd();

        builder.Property(o => o.ProductName)
            .HasColumnType("TEXT")
            .HasColumnName("product_name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(o => o.Price)
            .HasColumnType("REAL")
            .HasColumnName("price")
            .HasPrecision(8, 2)
            .IsRequired();

        builder.Property(o => o.Quantity)
            .HasColumnType("INTEGER")
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(o => o.RegisteredDate)
            .HasColumnType("TEXT")
            .HasColumnName("registered_date")
            .IsRequired();
    }
}

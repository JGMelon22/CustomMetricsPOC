using Microsoft.EntityFrameworkCore;
using CustomMetricsPOC.Models;
using CustomMetricsPOC.Infrastructure.Configuration;

namespace CustomMetricsPOC.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}

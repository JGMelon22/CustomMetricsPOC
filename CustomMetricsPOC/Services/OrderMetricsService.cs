using CustomMetricsPOC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Prometheus;

namespace CustomMetricsPOC.Services;

public class OrderMetricsService
{
    private static readonly Gauge OrderGauge = Metrics.CreateGauge("product_orders",
        "Total number of orders for each product",
        new GaugeConfiguration
        {
            LabelNames = new[] { "product_name" }
        });

    private readonly AppDbContext _dbContext;

    public OrderMetricsService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task UpdateOrderCountAsync()
    {
        try
        {
            var productQuantity = await _dbContext.Orders
                .Where(x => x.Price >= 100)
                .AsNoTracking()
                .GroupBy(x => x.ProductName)
                .Select(g => new
                {
                    ProductName = g.Key,
                    Count = g.Count(),
                    TotalQuantity = g.Sum(x => x.Quantity)
                })
                .ToListAsync();

            foreach (var product in productQuantity)
            {
                OrderGauge.WithLabels(product.ProductName).Set(product.Count);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Something went wrong with Gauge Metrics", ex);
        }
    }
}

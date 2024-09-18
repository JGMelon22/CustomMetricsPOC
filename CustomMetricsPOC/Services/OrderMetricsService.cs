using CustomMetricsPOC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Prometheus;

namespace CustomMetricsPOC.Services;

public class OrderMetricsService
{
    private static readonly Gauge OrderGauge = Metrics.CreateGauge("total_orders_count", "Total number of orders in the system");
    private readonly AppDbContext _dbContext;

    public OrderMetricsService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task UpdateOrderCountAsync()
    {
        short amountOfDays = -10;
        try
        {
            int amountOfOrders = await _dbContext.Orders
                .Where(x => x.RegisteredDate >= DateTime.Now.AddDays(amountOfDays))
                .CountAsync();

            OrderGauge.Set(amountOfOrders);
        }
        catch (Exception ex)
        {
            throw new Exception("Something went wrong with Gauge Metrics", ex);
        }
    }
}

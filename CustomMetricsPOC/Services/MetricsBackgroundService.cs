
namespace CustomMetricsPOC.Services;

public class MetricsBackgroundService : BackgroundService
{
    private readonly OrderMetricsService _orderMetricsService;

    public MetricsBackgroundService(OrderMetricsService orderMetricsService)
    {
        _orderMetricsService = orderMetricsService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _orderMetricsService.UpdateOrderCountAsync();
            await Task.Delay(10000, stoppingToken);
        }
    }
}

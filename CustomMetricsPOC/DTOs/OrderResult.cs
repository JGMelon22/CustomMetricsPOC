namespace CustomMetricsPOC.DTOs;

public record OrderResult
{
    public int Id { get; init; }
    public string ProductName { get; init; } = string.Empty!;
    public decimal Price { get; init; }
    public int Quantity { get; init; }
}

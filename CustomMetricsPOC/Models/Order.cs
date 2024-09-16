namespace CustomMetricsPOC.Models;

public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

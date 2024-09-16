using CustomMetricsPOC.DTOs;
using CustomMetricsPOC.Models;

namespace CustomMetricsPOC.Interfaces;

public interface IOrderRepository
{
    Task<ServiceResponse<OrderResult>> CreateOrderAsync(OrderDto newOrder);
    Task<ServiceResponse<ICollection<OrderResult>>> GetAllOrdersAsync();
    Task<ServiceResponse<OrderResult>> GetOrderByIdAsync(int id);
    Task<ServiceResponse<OrderResult>> UpdateOrderAsync(int id, OrderDto updatedOrder);
    Task<ServiceResponse<bool>> RemoveOrderAsync(int id);
}

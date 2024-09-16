using Microsoft.AspNetCore.Mvc;
using CustomMetricsPOC.DTOs;
using CustomMetricsPOC.Interfaces;

namespace CustomMetricsPOC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _repository;

    public OrdersController(IOrderRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddOrderAsync(OrderDto newOrder)
    {
        var order = await _repository.CreateOrderAsync(newOrder);

        return order.Data != null
            ? Ok(order)
            : BadRequest(order);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllOrdersAsync()
    {
        var orders = await _repository.GetAllOrdersAsync();
        return orders.Data != null && orders.Data.Any()
            ? Ok(orders)
            : NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrderByIdAsync(int id)
    {
        var order = await _repository.GetOrderByIdAsync(id);
        return order.Data != null
            ? Ok(order)
            : NotFound(order);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateOrderAsync(int id, OrderDto updatedOrder)
    {
        var order = await _repository.UpdateOrderAsync(id, updatedOrder);
        return order.Data != null
            ? Ok(order)
            : BadRequest(order);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveOrderAsync(int id)
    {
        var order = await _repository.RemoveOrderAsync(id);
        return order.Success != false
            ? NoContent()
            : BadRequest(order);
    }
}

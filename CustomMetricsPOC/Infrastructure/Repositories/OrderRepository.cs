using Microsoft.EntityFrameworkCore;
using CustomMetricsPOC.DTOs;
using CustomMetricsPOC.Exceptions;
using CustomMetricsPOC.Infrastructure.Data;
using CustomMetricsPOC.Interfaces;
using CustomMetricsPOC.Models;

namespace CustomMetricsPOC.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse<OrderResult>> CreateOrderAsync(OrderDto newOrder)
    {
        var serviceResponse = new ServiceResponse<OrderResult>();

        try
        {
            var order = new Order
            {
                ProductName = newOrder.ProductName,
                Price = newOrder.Price,
                Quantity = newOrder.Quantity
            };

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            var orderResult = new OrderResult
            {
                Id = order.Id,
                ProductName = order.ProductName,
                Price = order.Price,
                Quantity = order.Quantity
            };

            serviceResponse.Data = orderResult;
        }
        catch (OrderException ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<ICollection<OrderResult>>> GetAllOrdersAsync()
    {
        var serviceResponse = new ServiceResponse<ICollection<OrderResult>>();

        try
        {
            var orders = await _dbContext.Orders
                .AsNoTracking()
                .ToListAsync()
                ?? throw new OrderException("Order List is empty!");

            var mappedOrders = new List<OrderResult>();

            foreach (var order in orders)
            {
                var orderResult = new OrderResult
                {
                    Id = order.Id,
                    ProductName = order.ProductName,
                    Price = order.Price,
                    Quantity = order.Quantity
                };

                mappedOrders.Add(orderResult);
            }

            serviceResponse.Data = mappedOrders;
        }
        catch (OrderException ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<OrderResult>> GetOrderByIdAsync(int id)
    {
        var serviceResponse = new ServiceResponse<OrderResult>();

        try
        {
            var order = await _dbContext.Orders
                .FindAsync(id)
                ?? throw new OrderException($"Order with id {id} not found.");

            var orderResult = new OrderResult
            {
                Id = order.Id,
                ProductName = order.ProductName,
                Price = order.Price,
                Quantity = order.Quantity
            };

            serviceResponse.Data = orderResult;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> RemoveOrderAsync(int id)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var order = await _dbContext.Orders
                .FindAsync(id)
                ?? throw new OrderException($"Order with id {id} not found.");

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<OrderResult>> UpdateOrderAsync(int id, OrderDto updatedOrder)
    {
        var serviceResponse = new ServiceResponse<OrderResult>();

        try
        {
            var order = await _dbContext.Orders
                .FindAsync(id)
                ?? throw new OrderException($"Order with id {id} not found!");

            order.ProductName = updatedOrder.ProductName;
            order.Price = updatedOrder.Price;
            order.Quantity = updatedOrder.Quantity;

            await _dbContext.SaveChangesAsync();

            var orderResult = new OrderResult
            {
                Id = order.Id,
                ProductName = order.ProductName,
                Price = order.Price,
                Quantity = order.Quantity
            };

            serviceResponse.Data = orderResult;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}

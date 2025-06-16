using FastTechFoods.Worker.Application.Dtos;
using FastTechFoods.Worker.Application.Interfaces;
using FastTechFoods.Worker.Domain.Entities;
using FastTechFoods.Worker.Domain.Enums;
using FastTechFoods.Worker.Domain.Interfaces;

namespace FastTechFoods.Worker.Application.Services;

public class OrderAppService : IOrderAppService
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderAppService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Task UpdateOrder(ChangeStatusDto dto)
    {
        var order = _orderRepository.GetById(dto.OrderId);

        if (order is null)
            return Task.CompletedTask;
                
        order.LastUpdatedAt = DateTime.Now;
        order.Justification = dto.Justification;

        switch (dto.OrderStatus)
        {
            case OrderStatus.Accepted or OrderStatus.Rejected or OrderStatus.Cancelled when order.Status == OrderStatus.Created:
            case OrderStatus.InProgress when order.Status == OrderStatus.Accepted:
            case OrderStatus.Finished   when order.Status == OrderStatus.InProgress:
                order.Status = dto.OrderStatus;
                _orderRepository.UpdateOrder(order);
                return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}
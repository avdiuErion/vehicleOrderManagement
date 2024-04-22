using AutoMapper;
using OrderService.Domain;
using OrderService.Domain.Entities;
using AddOrderCommand = OrderService.ApplicationService.CQRS.Commands.AddOrderCommand.Command;

namespace OrderService.ApplicationService.Mapping;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<AddOrderCommand, Order>();
        CreateMap<OrderItem, SharedCore.Events.Order.OrderItem>();
    }
}
using OrderService.Domain;

namespace OrderService.ApplicationService.Interfaces;

public interface IOrderService
{
    public Task<Guid> AddOrder(Order order);
}
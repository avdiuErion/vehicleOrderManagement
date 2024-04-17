using OrderService.ApplicationService.Interfaces;
using OrderService.Domain;

namespace OrderService.ApplicationService.Services;

public class OrderService : IOrderService
{
    public Task<Guid> AddOrder(Order order)
    {
        throw new NotImplementedException();
    }
}
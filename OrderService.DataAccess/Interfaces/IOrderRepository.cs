using OrderService.Domain;
using SharedCore.Interfaces;

namespace OrderService.DataAccess.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    
}
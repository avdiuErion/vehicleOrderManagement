using OrderService.DataAccess.Interfaces;
using OrderService.Domain;
using OrderService.Domain.Context;
using SharedCore.Implementations;

namespace OrderService.DataAccess.Implementations;

public class OrderRepository(ApplicationDbContext dbContext) : BaseRepository<Order>(dbContext), IOrderRepository
{
    
}
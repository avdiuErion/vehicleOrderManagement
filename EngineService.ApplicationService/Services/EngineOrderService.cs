using EngineService.ApplicationService.Interfaces;
using EngineService.DataAccess.Interfaces;
using EngineService.Domain.Entities;

namespace EngineService.ApplicationService.Services;

public class EngineOrderService(IEngineOrderRepository engineOrderRepository) : IEngineOrderService
{
    public async Task AddEngineOrder(EngineOrder entity)
    {
        await engineOrderRepository.AddAsync(entity);
    }
}
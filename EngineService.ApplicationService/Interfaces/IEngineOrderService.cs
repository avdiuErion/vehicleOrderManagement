using EngineService.Domain.Entities;

namespace EngineService.ApplicationService.Interfaces;

public interface IEngineOrderService
{
    Task AddEngineOrder(EngineOrder engineOrder);
}
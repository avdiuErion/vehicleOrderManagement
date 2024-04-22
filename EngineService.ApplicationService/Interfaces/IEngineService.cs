using EngineService.Domain.Entities;

namespace EngineService.ApplicationService.Interfaces;

public interface IEngineService
{
    Task AddEngine(Engine engine);
    Task<Engine> GetById(Guid id);
}
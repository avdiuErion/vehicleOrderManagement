using EngineService.ApplicationService.Interfaces;
using EngineService.DataAccess.Interfaces;
using EngineService.Domain.Entities;

namespace EngineService.ApplicationService.Services;

public class EngineService(IEngineRepository engineRepository) : IEngineService
{
    public async Task AddEngine(Engine engine)
    {
        await engineRepository.AddAsync(engine);
    }

    public Task<Engine> GetById(Guid id)
    {
        return engineRepository.GetByIdAsync(id)!;
    }
}
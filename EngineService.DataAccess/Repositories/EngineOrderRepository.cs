using EngineService.DataAccess.Interfaces;
using EngineService.Domain.Context;
using EngineService.Domain.Entities;
using SharedCore.Implementations;

namespace EngineService.DataAccess.Repositories;

public class EngineOrderRepository(ApplicationDbContext context)
    : BaseRepository<EngineOrder>(context), IEngineOrderRepository;
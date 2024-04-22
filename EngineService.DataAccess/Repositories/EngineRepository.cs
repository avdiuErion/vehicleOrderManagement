using EngineService.DataAccess.Interfaces;
using EngineService.Domain.Context;
using EngineService.Domain.Entities;
using SharedCore.Implementations;

namespace EngineService.DataAccess.Repositories;

public class EngineRepository(ApplicationDbContext context) : BaseRepository<Engine>(context), IEngineRepository;
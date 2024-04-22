using ChassisService.Domain.Context;
using ChassisService.Domain.Entities;
using ChassissService.DataAccess.Interfaces;
using SharedCore.Implementations;

namespace ChassissService.DataAccess.Repositories;

public class ChassisOrderRepository(ApplicationDbContext context)
    : BaseRepository<ChassisOrder>(context), IChassisOrderRepository;
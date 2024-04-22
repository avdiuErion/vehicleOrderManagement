using SharedCore.Implementations;
using Warehouse.DataAccess.Interfaces;
using Warehouse.Domain.Context;
using Warehouse.Domain.Entities;

namespace Warehouse.DataAccess.Repositories;

public class VehicleRepository(ApplicationDbContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
    
}
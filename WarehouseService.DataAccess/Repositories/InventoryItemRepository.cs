using Microsoft.EntityFrameworkCore;
using SharedCore.Implementations;
using Warehouse.DataAccess.Interfaces;
using Warehouse.Domain.Context;
using Warehouse.Domain.Entities;

namespace Warehouse.DataAccess.Repositories;

public class InventoryItemRepository(ApplicationDbContext context) : BaseRepository<InventoryItem>(context), IInventoryItemRepository
{
    
}
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Interfaces;
using Warehouse.Domain.Entities;
using WarehouseService.ApplicationService.Interfaces;

namespace WarehouseService.ApplicationService.Services;

public class WarehouseService(IInventoryItemRepository inventoryItemRepository) : IWarehouseService
{
    public async Task<IEnumerable<InventoryItem>> GetAllInventoryItems()
    {
        return (await inventoryItemRepository.GetAll().ToListAsync())!;
    }
}
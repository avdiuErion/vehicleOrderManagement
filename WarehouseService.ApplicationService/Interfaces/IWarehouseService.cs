using Warehouse.Domain.Entities;

namespace WarehouseService.ApplicationService.Interfaces;

public interface IWarehouseService
{
    Task<IEnumerable<InventoryItem>> GetAllInventoryItems();
}
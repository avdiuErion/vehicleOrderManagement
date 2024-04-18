using SharedCore.Dtos;

namespace SharedCore.Clients.Interfaces;

public interface IWarehouseClient
{
    Task<InventoryResponseDto?> CheckForInventory(object inventory);
}
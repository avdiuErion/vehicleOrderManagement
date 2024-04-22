using SharedCore.Dtos;

namespace SharedCore.Clients.Interfaces;

public interface IWarehouseClient
{
    Task<List<StockItemDto>?> GetStockItems();
}
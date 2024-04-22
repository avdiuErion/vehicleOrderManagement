using SharedCore.Enums;

namespace WarehouseService.ApplicationService.CQRS.Queries.GetAllStockItemsQuery;

public class QueryResponse
{
    public string ProductId { get; set; }
    public int AvailableQuantity { get; set; }
    public ProductType? Type { get; set; }
}
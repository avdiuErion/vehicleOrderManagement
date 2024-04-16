using SharedCore.BaseClasses;

namespace InventoryService.Domain;

public class Product : BaseEntity
{
    public string Name { get; set; }
    
    public List<StockItem> StockItems { get; set; }
}
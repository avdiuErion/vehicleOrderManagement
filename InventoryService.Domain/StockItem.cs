using SharedCore.BaseClasses;

namespace InventoryService.Domain;

public class StockItem : BaseEntity
{
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    
    public Product Product { get; set; }
}
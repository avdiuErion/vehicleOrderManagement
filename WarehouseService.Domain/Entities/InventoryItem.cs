using SharedCore.BaseClasses;

namespace Warehouse.Domain.Entities;

public class InventoryItem : BaseEntity
{
    public string ProductId { get; set; }
    public int AvailableQuantity { get; set; }
}
using SharedCore.BaseClasses;

namespace Warehouse.Domain.Entities;

public class Vehicle : BaseEntity
{
    public string Description { get; set; }
    public bool isAssembled { get; set; }
    public ICollection<InventoryItem> InventoryItems { get; set; }
}
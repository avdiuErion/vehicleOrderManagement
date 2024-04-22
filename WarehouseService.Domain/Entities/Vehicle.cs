using SharedCore.BaseClasses;

namespace Warehouse.Domain.Entities;

public class Vehicle : BaseEntity
{
    public string Description { get; set; }
    public bool IsAssembled { get; set; }
    public Guid? OrderId { get; set; }
    public ICollection<InventoryItem> InventoryItems { get; set; }
}
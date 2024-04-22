using SharedCore.BaseClasses;
using SharedCore.Enums;

namespace ChassisService.Domain.Entities;

public class ChassisOrder : BaseEntity
{
    public string? Description { get; set; }
    public ProductionState ProductionState { get; set; }
    public Guid ChassisId { get; set; }
}
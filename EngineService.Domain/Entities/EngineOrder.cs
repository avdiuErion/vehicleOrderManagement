using SharedCore.BaseClasses;
using SharedCore.Enums;

namespace EngineService.Domain.Entities;

public class EngineOrder : BaseEntity
{
    public string Description { get; set; }
    public ProductionState ProductionState { get; set; }
    public Guid EngineId { get; set; }
}
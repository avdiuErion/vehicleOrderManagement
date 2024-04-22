using SharedCore.BaseClasses;
using SharedCore.Enums;

namespace OptionPacksService.Domain.Entities;

public class OptionPackOrder : BaseEntity
{
    public string Description { get; set; }
    public ProductionState ProductionState { get; set; }
    public Guid OptionPackId { get; set; }
}
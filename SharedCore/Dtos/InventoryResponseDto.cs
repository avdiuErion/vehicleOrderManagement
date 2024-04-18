namespace SharedCore.Dtos;

public class InventoryResponseDto
{
    public IEnumerable<StockItemDto>? MissingItems { get; }
}
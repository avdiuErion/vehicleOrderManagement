using SharedCore.Enums;

namespace SharedCore.Dtos;

public class StockItemDto
{
    public string ProductId { get; set; }
    public int AvailableQuantity { get; set; }
    
    public ProductType Type { get; set; }
}
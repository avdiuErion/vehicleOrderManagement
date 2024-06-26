using AutoMapper;
using SharedCore.Events.Order;
using Warehouse.Domain.Entities;
using WarehouseService.ApplicationService.CQRS.Queries.GetAllStockItemsQuery;

namespace WarehouseService.ApplicationService.Mappings;

public class WarehouseMappingProfile : Profile
{
    public WarehouseMappingProfile()
    {
        CreateMap<InventoryItem, QueryResponse>();
        CreateMap<OrderItem, InventoryItem>();
    }
}
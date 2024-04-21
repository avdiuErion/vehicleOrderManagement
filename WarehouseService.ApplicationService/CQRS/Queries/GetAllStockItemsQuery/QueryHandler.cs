using AutoMapper;
using MediatR;
using WarehouseService.ApplicationService.Interfaces;

namespace WarehouseService.ApplicationService.CQRS.Queries.GetAllStockItemsQuery;

public class QueryHandler(IWarehouseService warehouseService, IMapper mapper) : IRequestHandler<Query, List<QueryResponse>>
{
    public async Task<List<QueryResponse>> Handle(Query request, CancellationToken cancellationToken)
    {
        return mapper.Map<List<QueryResponse>>(await warehouseService.GetAllInventoryItems());
    }
}
using MediatR;

namespace WarehouseService.ApplicationService.CQRS.Queries.GetAllStockItemsQuery;

public class Query : IRequest<List<QueryResponse>>
{
    
}
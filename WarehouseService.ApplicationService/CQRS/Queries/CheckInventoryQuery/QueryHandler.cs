using MediatR;

namespace WarehouseService.ApplicationService.CQRS.Queries.CheckInventoryQuery;

public class QueryHandler : IRequestHandler<Query, QueryResponse>
{
    public Task<QueryResponse> Handle(Query request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
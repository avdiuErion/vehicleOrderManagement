using MediatR;

namespace OptionPacksService.ApplicationService.CQRS.Queries.GetAll;

public class QueryHandler : IRequestHandler<Query, List<QueryResponse>>
{
    public Task<List<QueryResponse>> Handle(Query request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
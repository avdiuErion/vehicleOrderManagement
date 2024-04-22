using AutoMapper;
using GetAllQueryResponse = EngineService.ApplicationService.CQRS.Queries.GetAll.QueryResponse;
using EngineService.Domain.Entities;

namespace EngineService.ApplicationService.Mappings;

public class EngineMappingProfile : Profile
{
    public EngineMappingProfile()
    {
        CreateMap<Engine, GetAllQueryResponse>();
    }
}
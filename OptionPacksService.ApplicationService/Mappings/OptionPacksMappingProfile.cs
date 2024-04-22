using AutoMapper;
using GetAllQueryResponse = OptionPacksService.ApplicationService.CQRS.Queries.GetAll.QueryResponse;
using OptionPacksService.Domain.Entities;

namespace OptionPacksService.ApplicationService.Mappings;

public class OptionPacksMappingProfile : Profile
{
    public OptionPacksMappingProfile()
    {
        CreateMap<OptionPack, GetAllQueryResponse>();
    }
}
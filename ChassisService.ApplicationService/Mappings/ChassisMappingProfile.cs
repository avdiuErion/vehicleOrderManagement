using AutoMapper;
using ChassisService.Domain.Entitites;
using GetAllQueryResponse = ChassisService.ApplicationService.CQRS.Queries.GetAll.QueryResponse;

namespace ChassisService.ApplicationService.Mappings;

public class ChassisMappingProfile : Profile
{
    public ChassisMappingProfile()
    {
        CreateMap<Chassis, GetAllQueryResponse>();
    }
}
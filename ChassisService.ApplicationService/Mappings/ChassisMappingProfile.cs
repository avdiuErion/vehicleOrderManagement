using AutoMapper;
using ChassisService.Domain.Entities;
using GetAllQueryResponse = ChassisService.ApplicationService.CQRS.Queries.GetAll.QueryResponse;

namespace ChassisService.ApplicationService.Mappings;

public class ChassisMappingProfile : Profile
{
    public ChassisMappingProfile()
    {
        CreateMap<Chassis, GetAllQueryResponse>();
    }
}
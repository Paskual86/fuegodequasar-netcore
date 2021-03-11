using AutoMapper;
using FuegoDeQuasar.Domain.Entities;
using FuegoDeQuasar.Dtos;

namespace FuegoDeQuasar.EntityMapper.Profiles
{
    public class MappingDtoProfile : Profile
    {
        public MappingDtoProfile()
        {
            CreateMap<Location, PositionDto>().ReverseMap();
            CreateMap<SatelliteRequest, SatelliteRequestDto>().ReverseMap();
            CreateMap<SatelliteResponse, SatelliteResponseDto>().ReverseMap();
        }
    }
}

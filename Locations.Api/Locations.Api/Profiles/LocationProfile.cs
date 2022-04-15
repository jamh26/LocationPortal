using AutoMapper;
using Locations.Api.Dtos;
using Locations.Api.Models;

namespace Locations.Api.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            // Source -> Target
            CreateMap<Location, LocationReadDto>();
            CreateMap<LocationCreateDto, Location>();
        }
    }
}
using AutoMapper;
using Locations.Api.Dtos;
using Locations.Api.Models;

namespace Locations.Api.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationReadDto>();
        }
    }
}
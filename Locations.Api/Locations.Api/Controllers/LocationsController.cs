using AutoMapper;
using Locations.Api.Data;
using Locations.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Locations.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepo _repository;
        private readonly IMapper _mapper;

        public LocationsController(ILocationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/locations
        [HttpGet]
        public ActionResult<IEnumerable<LocationReadDto>> GetAllLocations()
        {
            var locationItems = _repository.GetAllLocations();
            return Ok(_mapper.Map<IEnumerable<LocationReadDto>>(locationItems));
        }

        // GET api/locations/{id}
        [HttpGet("{id}")]
        public ActionResult<LocationReadDto> GetLocationById(int id)
        {
            var locationItem = _repository.GetLocationById(id);
            if (locationItem != null)
            {
                return Ok(_mapper.Map<LocationReadDto>(locationItem));
            }
            return NotFound();
        }
    }
}
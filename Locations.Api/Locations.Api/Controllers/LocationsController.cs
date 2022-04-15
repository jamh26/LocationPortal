using AutoMapper;
using Locations.Api.Data;
using Locations.Api.Dtos;
using Locations.Api.Models;
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
        [HttpGet("{id}", Name = "GetLocationById")]
        public ActionResult<LocationReadDto> GetLocationById(int id)
        {
            var locationItem = _repository.GetLocationById(id);
            if (locationItem != null)
            {
                return Ok(_mapper.Map<LocationReadDto>(locationItem));
            }
            return NotFound();
        }

        // POST api/locations
        [HttpPost]
        public ActionResult<LocationReadDto> CreateLocation(LocationCreateDto locationCreateDto)
        {
            var locationModel = _mapper.Map<Location>(locationCreateDto);
            _repository.CreatLocation(locationModel);
            _repository.SaveChanges();

            var locationReadDto = _mapper.Map<LocationReadDto>(locationModel);

            //return Ok(locationReadDto);
            return CreatedAtRoute(nameof(GetLocationById), new { Id = locationReadDto.Id }, locationReadDto);
        }

        // PUT /api/locations/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateLocation(int id, LocationUpdateDto locationUpdateDto)
        {
            var locationModelFromRepo = _repository.GetLocationById(id);
            if(locationModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(locationUpdateDto, locationModelFromRepo);

            _repository.UpdateLocation(locationModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
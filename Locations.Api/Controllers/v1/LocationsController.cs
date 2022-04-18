using AutoMapper;
using Locations.Api.Data;
using Locations.Api.Dtos;
using Locations.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Locations.Api.Controllers.v1
{
    public class LocationsController : BaseController
    {
        private readonly ILocationRepo _repository;
        private readonly IMapper _mapper;

        public LocationsController(ILocationRepo repository, IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork)
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

        // PATCH /api/locations/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialLocationUpdate(int id, JsonPatchDocument<LocationUpdateDto> patchDoc)
        {
            var locationModelFromRepo = _repository.GetLocationById(id);
            if (locationModelFromRepo == null)
            {
                return NotFound();
            }

            var locationToPatch = _mapper.Map<LocationUpdateDto>(locationModelFromRepo);

            patchDoc.ApplyTo(locationToPatch, ModelState);
            if (!TryValidateModel(locationToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(locationToPatch, locationModelFromRepo);

            _repository.UpdateLocation(locationModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/locations/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteLocation(int id)
        {
            var locationModelFromRepo = _repository.GetLocationById(id);
            if (locationModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteLocation(locationModelFromRepo);
            _repository.SaveChanges();
            
            return NoContent();

        }
    }
}
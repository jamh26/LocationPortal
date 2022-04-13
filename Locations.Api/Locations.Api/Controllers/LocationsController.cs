using Locations.Api.Data;
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

        public LocationsController(ILocationRepo repository)
        {
            _repository = repository;
        }

        // GET api/locations
        [HttpGet]
        public ActionResult <IEnumerable<Location>> GetAllLocations()
        {
            var locationItems = _repository.GetAllLocations();
            return Ok(locationItems);
        }

        // GET api/locations/{id}
        [HttpGet("{id}")]
        public ActionResult <Location> GetLocationById(int id)
        {
            var locationItem = _repository.GetLocationById(id);
            return Ok(locationItem);
        }
    }
}
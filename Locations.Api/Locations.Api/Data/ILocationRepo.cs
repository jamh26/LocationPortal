using Locations.Api.Models;
using System.Collections.Generic;

namespace Locations.Api.Data
{
    public interface ILocationRepo
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(int id);
    }
}
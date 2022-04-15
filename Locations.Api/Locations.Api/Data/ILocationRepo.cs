using Locations.Api.Models;
using System.Collections.Generic;

namespace Locations.Api.Data
{
    public interface ILocationRepo
    {
        bool SaveChanges();

        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(int id);
        void CreatLocation(Location location);
    }
}
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
        void UpdateLocation(Location location);
        bool DeleteLocation(Location location);
        bool UpsertLocation(Location location);
    }
}
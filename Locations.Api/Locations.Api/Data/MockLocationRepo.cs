using Locations.Api.Models;
using System.Collections.Generic;

namespace Locations.Api.Data
{
    public class MockLocationRepo : ILocationRepo
    {
        public void CreatLocation(Location location)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLocation(Location location)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            var locations = new List<Location>
            {
                new Location
                {
                    Id = 0,
                    PhysicalAddress = "6905 Via Del Cerro Rd NE",
                    City = "Albuquerque",
                    Country = "USA",
                    State = "New Mexico",
                    ZipCode = "87113"
                },
                new Location
                {
                    Id = 1,
                    PhysicalAddress = "6909 Via Del Cerro Rd NE",
                    City = "Albuquerque",
                    Country = "USA",
                    State = "New Mexico",
                    ZipCode = "87113"
                },
                new Location
                {
                    Id = 2,
                    PhysicalAddress = "6914 Via Del Cerro Rd NE",
                    City = "Albuquerque",
                    Country = "USA",
                    State = "New Mexico",
                    ZipCode = "87113"
                }
            };

            return locations;
        }

        public Location GetLocationById(int id)
        {
            return new Location
            {
                Id = 0,
                PhysicalAddress = "6905 Via Del Cerro Rd NE",
                City = "Albuquerque",
                Country = "USA",
                State = "New Mexico",
                ZipCode = "87113"
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLocation(Location location)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertLocation(Location location)
        {
            throw new System.NotImplementedException();
        }
    }
}
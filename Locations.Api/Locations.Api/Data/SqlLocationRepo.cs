using Locations.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locations.Api.Data
{
    public class SqlLocationRepo : ILocationRepo
    {
        private readonly LocationContext _context;

        public SqlLocationRepo(LocationContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public Location GetLocationById(int id)
        {
            return _context.Locations.FirstOrDefault(p => p.Id == id);
        }
    }
}
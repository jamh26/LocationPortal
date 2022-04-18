using Locations.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locations.Api.Data
{
    public class SqlLocationRepo : ILocationRepo
    {
        private readonly ApplicationDbContext _context;

        public SqlLocationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreatLocation(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            try
            {
                var result = _context.Add(location);
                return SaveChanges();
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteLocation(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }
            try
            {
                var result = _context.Remove(location);
                return SaveChanges();
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public Location GetLocationById(int id)
        {
            return _context.Locations.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            try
            {
                return (_context.SaveChanges() >= 0);
            }
            catch
            {
                return false;
            }
        }

        public void UpdateLocation(Location location)
        {
            // nothing
        }

        public bool UpsertLocation(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
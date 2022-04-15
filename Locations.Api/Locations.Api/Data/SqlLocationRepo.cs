﻿using Locations.Api.Models;
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

        public void CreatLocation(Location location)
        {
            if(location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            _context.Locations.Add(location);
        }

        public void DeleteLocation(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            _context.Locations.Remove(location);
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
            return (_context.SaveChanges() >= 0);
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
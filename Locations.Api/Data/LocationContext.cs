using Locations.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Locations.Api.Data
{
    public class LocationContext : DbContext
    {
        public LocationContext(DbContextOptions<LocationContext> opt) : base(opt)
        {
        }

        public DbSet<Location> Locations { get; set; }
    }
}
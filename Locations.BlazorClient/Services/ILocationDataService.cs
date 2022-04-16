using Locations.BlazorClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locations.BlazorClient.Services
{
    public interface ILocationDataService
    {
        Task<IEnumerable<LocationData>> GetAllLocations();

        Task<LocationData> GetLocationDetails(int id);
    }
}
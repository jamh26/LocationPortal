using Locations.BlazorClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locations.BlazorClient.Services
{
    public interface ILocationDataService
    {
        Task<IEnumerable<LocationData>> GetAllLocations();

        Task<LocationData> GetLocationDetails(int id);

        Task<LocationData> AddLocation(LocationData location);

        Task UpdateLocation(LocationData location);

        Task DeleteLocation(int id);
    }
}
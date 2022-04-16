using Locations.BlazorClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Locations.BlazorClient.Services
{
    public class LocationDataService : ILocationDataService
    {
        private readonly HttpClient _httpClient;

        public LocationDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LocationData>> GetAllLocations()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/locations");
            return await JsonSerializer.DeserializeAsync<IEnumerable<LocationData>>
                (apiResponse, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task<LocationData> GetLocationDetails(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/locations/{id}");
            return await JsonSerializer.DeserializeAsync<LocationData>
                (apiResponse, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
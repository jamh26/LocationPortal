using Locations.BlazorClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public async Task<LocationData> AddLocation(LocationData location)
        {
            try
            {
                var locationJson = new StringContent(JsonSerializer.Serialize(location), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/locations", locationJson);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<LocationData>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task DeleteLocation(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/locations/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        public async Task UpdateLocation(LocationData location)
        {
            try
            {
                var LocationJson = new StringContent(JsonSerializer.Serialize(location), Encoding.UTF8, "application/json");

                var url = $"api/locations/{location.Id}";

                var response = await _httpClient.PutAsync(url, LocationJson);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
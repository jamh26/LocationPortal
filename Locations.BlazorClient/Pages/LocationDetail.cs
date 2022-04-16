using Locations.BlazorClient.Models;
using Locations.BlazorClient.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Locations.BlazorClient.Pages
{
    public partial class LocationDetail
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public ILocationDataService LocationDataService { get; set; }

        public LocationData Location { get; set; } = new LocationData();

        protected override async Task OnInitializedAsync()
        {
            var locationId = Convert.ToInt32(Id);
            Location = await LocationDataService.GetLocationDetails(locationId);
        }
    }
}
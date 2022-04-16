using Locations.BlazorClient.Models;
using Locations.BlazorClient.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locations.BlazorClient.Pages
{
    public partial class LocationOverview
    {
        public IEnumerable<LocationData> Locations { get; set; }

        [Inject]
        public ILocationDataService LocationDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Locations = (await LocationDataService.GetAllLocations()).ToList();
        }
    }
}
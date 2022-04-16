using Locations.BlazorClient.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Locations.BlazorClient.Pages
{
    public partial class LocationDetail
    {
        [Parameter]
        public string Id { get; set; }

        public LocationData Location { get; set; } = new LocationData();

        private void InitializeLocation()
        {
            var l1 = new LocationData
            {
                Id = 1,
                PhysicalAddress = "8493 this is not real",
                ZipCode = "32446",
                City = "bosque farms",
                State = "New Mexico",
                Country = "USA"
            };

            Location = l1;
        }

        protected override Task OnInitializedAsync()
        {
            InitializeLocation();
            return base.OnInitializedAsync();
        }
    }
}
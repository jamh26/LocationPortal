using System.Collections.Generic;
using System.Threading.Tasks;
using Locations.BlazorClient.Models;

namespace Locations.BlazorClient.Pages
{
    public partial class LocationOverview
    {
        public IEnumerable<LocationData> Locations { get; set; }

        private void InitializeLocations()
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
            var l2 = new LocationData
            {
                Id = 2,
                PhysicalAddress = "2394 this is not real",
                ZipCode = "98761",
                City = "peralta",
                State = "New Mexico",
                Country = "USA"
            };

            Locations = new List<LocationData> { l1, l2 };
        }

        protected override Task OnInitializedAsync()
        {
            InitializeLocations();
            return base.OnInitializedAsync();
        }
    }
}
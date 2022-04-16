using Locations.BlazorClient.Models;
using Locations.BlazorClient.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Locations.BlazorClient.Pages
{
    public partial class LocationEdit
    {
        // State Management
        protected string Message = string.Empty;

        protected bool Saved;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocationDataService LocationDataService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public LocationData Location { get; set; } = new LocationData();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            if (!string.IsNullOrEmpty(Id))
            {
                var locationId = Convert.ToInt32(Id);
                Location = await LocationDataService.GetLocationDetails(locationId);
            }
        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id)) // We need to add the location
            {
                var result = await LocationDataService.AddLocation(Location);

                if (result != null)
                {
                    Saved = true;
                    Message = "Location has been added";
                }
                else
                {
                    Message = "Something went wrong";
                }
            }
            else
            {
                await LocationDataService.UpdateLocation(Location);
                Saved = true;
                Message = "Location has been updated";
            }
        }

        protected void HandleInvalidRequest()
        {
            Message = "Failed to submit form";
        }

        protected void GoToOverview()
        {
            NavigationManager.NavigateTo("/LocationOverview");
        }

        protected async Task DeleteLocation()
        {
            if (!String.IsNullOrEmpty(Id))
            {
                var locationId = Convert.ToInt32(Id);
                await LocationDataService.DeleteLocation(locationId);

                NavigationManager.NavigateTo("/LocationOverview");
            }

            Message = "Something went wrong, unable to delete";
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Locations.BlazorClient.Models
{
    public class LocationData
    {
        public int Id { get; set; }

        [Required]
        public string PhysicalAddress { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        public string State { get; set; } = "New Mexico";

        public string Country { get; set; } = "USA";
    }
}
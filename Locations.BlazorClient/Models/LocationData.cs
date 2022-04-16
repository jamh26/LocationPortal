namespace Locations.BlazorClient.Models
{
    public class LocationData
    {
        public int Id { get; set; }

        public string PhysicalAddress { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; } = "New Mexico";

        public string Country { get; set; } = "USA";
    }
}
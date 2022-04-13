namespace Locations.Api.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
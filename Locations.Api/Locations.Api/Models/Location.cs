using System.ComponentModel.DataAnnotations;

namespace Locations.Api.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string PhysicalAddress { get; set; }
        [Required]
        [MaxLength(5)]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(250)]
        public string City { get; set; }
        [Required]
        [MaxLength(250)]
        public string State { get; set; }
        [Required]
        [MaxLength(250)]
        public string Country { get; set; }
    }
}
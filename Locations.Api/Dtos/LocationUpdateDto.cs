using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locations.Api.Dtos
{
    public class LocationUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string PhysicalAddress { get; set; }
        [Required]
        [MaxLength(250)]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(250)]
        public string City { get; set; }
    }
}

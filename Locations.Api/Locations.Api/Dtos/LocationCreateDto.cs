using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locations.Api.Dtos
{
    public class LocationCreateDto
    {
        public string PhysicalAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}

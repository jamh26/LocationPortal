using System.Collections.Generic;

namespace Locations.Api.Authentication.Models.Dtos.Outgoing
{
    public class AuthResultDto
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
using Locations.BlazorClient.Models;
using System.Threading.Tasks;

namespace Locations.BlazorClient.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUserModel> Login(AuthenticationUserModel userForAuthentication);
        Task Logout();
    }
}
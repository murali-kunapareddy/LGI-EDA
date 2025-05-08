using System.Security.Claims;

namespace WISSEN.EDA.Services
{
    public interface ICustomAuthenticationService
    {
        Task<ClaimsPrincipal> AuthenticateUser(string email, string password);
        Task SignIn(HttpContext httpContext, ClaimsPrincipal principal);
        Task SignOut(HttpContext httpContext);
        Task<string> GetUserRole(string email);
    }
}

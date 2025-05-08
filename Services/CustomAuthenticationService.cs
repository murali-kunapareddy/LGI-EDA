using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

using WISSEN.EDA.Helpers;
using WISSEN.EDA.Repositories;

namespace WISSEN.EDA.Services
{
    public class CustomAuthenticationService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository; // Use the repository
        private readonly IUserRoleRepository _userRoleRepository;

        public CustomAuthenticationService(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<ClaimsPrincipal> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return null; // User not found or not approved
            }

            // Verify the password
            if (!PasswordHasher.VerifyPassword(password, user.PasswordSalt, user.PasswordHash))
            {
                return null; // Invalid password
            }

            // Get User Role
            var role = await GetUserRole(email); // Await the task to resolve the issue

            // Create claims
            //var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, email),
            //        new Claim(ClaimTypes.Role, userRole), // Add the user's role as a claim
            //    };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, role) // Default role
            };

            var identity = new ClaimsIdentity(claims, "custom");
            return new ClaimsPrincipal(identity);
        }

        public async Task SignIn(HttpContext httpContext, ClaimsPrincipal principal)
        {
            await httpContext.SignInAsync("custom", principal);
        }

        public async Task SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync("custom");
        }

        public async Task<string> GetUserRole(string email)
        {
            // Get the user's role from the database.
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return "USER"; // Default to "USER" if user not found
            }
            var userRole = await _userRoleRepository.GetByUserEmailAsync(user.Email!); // Use the repo
            //var userRole = await _userRoleRepository.GetByIdAsync(user.Id);
            return userRole.RoleCode ?? "USER"; // Default to "USER" if no role found.
        }
    }
}

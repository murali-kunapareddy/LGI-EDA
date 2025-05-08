namespace WISSEN.EDA.Services
{
    public static class AuthorizationPolicies
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ViewRole", policy =>
                    policy.RequireRole("ADMN", "MNGR")); // Example: Only Admin and Editor can view roles
                options.AddPolicy("EditRole", policy =>
                    policy.RequireRole("ADMN"));       // Example: Only Admin can edit roles
                options.AddPolicy("CreateRole", policy =>
                    policy.RequireRole("ADMN"));
                options.AddPolicy("DeleteRole", policy =>
                    policy.RequireRole("ADMN"));
                options.AddPolicy("ViewUser", policy =>
                   policy.RequireRole("ADMN", "MNGR"));
                options.AddPolicy("EditUser", policy =>
                    policy.RequireRole("ADMN"));
                options.AddPolicy("CreateUser", policy =>
                   policy.RequireRole("ADMN"));
                options.AddPolicy("DeleteUser", policy =>
                    policy.RequireRole("ADMN"));
                options.AddPolicy("ApproveUser", policy =>
                    policy.RequireRole("ADMN","USER"));
                options.AddPolicy("CreateCompany", policy =>
                    policy.RequireRole("ADMN"));
            });
        }
    }
}

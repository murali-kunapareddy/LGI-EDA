using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Repositories;
using WISSEN.EDA.Repositories.Implementations;
using WISSEN.EDA.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
// db context
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(builder.Configuration.GetValue<string>("ConStrToUse")!)),
    ServiceLifetime.Transient);
// register repostories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
// Add custom authentication service
builder.Services.AddScoped<ICustomAuthenticationService, CustomAuthenticationService>();
// Add Authentication
builder.Services.AddAuthentication("custom")
    .AddCookie("custom", options =>
    {
        options.Cookie.Name = "UserAuthCookie"; // Customize cookie name
        options.LoginPath = "/BackOps/Login";    // Specify login path
        options.LogoutPath = "/BackOps/Logout";   // Specify logout path
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set cookie expiration
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/CommCenter/AccessDenied";
    });
// Add Authorization policies
builder.Services.AddAuthorizationPolicies();

var app = builder.Build();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDBContext>();
        var logger = services.GetRequiredService<ILogger<Program>>();

        await context.Database.MigrateAsync(); // Apply pending migrations
        await SeedService.SeedMasterDataAsync(context, logger);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");

        // In production, you might want to fail fast if seeding fails
        if (!app.Environment.IsDevelopment())
        {
            throw;
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// check if the user is authenticated
app.Use(async (context, next) =>
{
    await next();

    // Check if the response status code is 401 (Unauthorized)
    if (context.Response.StatusCode == 401)
    {
        var origin = context.Request.Path; // Capture the request origin
        var method = context.Request.Method; // Capture the request method

        // Redirect to the UnAuthorized action
        context.Response.Redirect($"/CommCenter/UnAuthorized?origin={origin}&method={method}");
    }
});

app.UseAuthentication();
app.UseAuthorization();
// Ensure authentication is checked before authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BackOps}/{action=login}/{id?}");

await app.RunAsync();

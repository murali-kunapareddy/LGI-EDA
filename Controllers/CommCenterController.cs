using Microsoft.AspNetCore.Mvc;

public class CommCenterController : Controller
{
    private readonly IConfiguration _configuration;
    public CommCenterController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult NotApproved()
    {
        ViewBag.AdminEmail = _configuration["AdminEmail"]; // Fetch admin email from configuration
        return View();
    }

    [HttpGet]
    public IActionResult UnAuthorized(string origin, string method)
    {
        ViewBag.Origin = origin;
        ViewBag.Method = method;
        return View();
    }

    [HttpGet]
    public IActionResult AccessDenied(string returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }
}

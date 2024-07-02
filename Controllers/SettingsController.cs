using Microsoft.AspNetCore.Mvc;

namespace EDA.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

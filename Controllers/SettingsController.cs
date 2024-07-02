using Microsoft.AspNetCore.Mvc;

namespace EDA.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Companies()
        {
            return View();
        }

    }
}

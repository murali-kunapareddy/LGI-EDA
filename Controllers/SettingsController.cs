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

        public IActionResult Countries()
        {
            return View();
        }

        public IActionResult PlantLocations()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace EDA.Controllers
{
    public class MastersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

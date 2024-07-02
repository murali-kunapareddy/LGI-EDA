using Microsoft.AspNetCore.Mvc;

namespace EDA.Controllers
{
    public class CommCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

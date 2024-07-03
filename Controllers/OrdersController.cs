using Microsoft.AspNetCore.Mvc;

namespace EDA.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

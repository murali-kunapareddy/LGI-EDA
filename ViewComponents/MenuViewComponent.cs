using Microsoft.AspNetCore.Mvc;

namespace WISSEN.EDA.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

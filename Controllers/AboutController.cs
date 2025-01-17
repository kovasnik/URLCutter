using Microsoft.AspNetCore.Mvc;

namespace URLCutter.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit(string description)
        {
            if (User.IsInRole("Admin"))
            {
                //
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

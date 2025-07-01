using Microsoft.AspNetCore.Mvc;

namespace WebAPI_project.Controllers
{
    public class DonorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

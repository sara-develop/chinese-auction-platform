using Microsoft.AspNetCore.Mvc;

namespace WebAPI_project.Controllers
{
    public class PrizesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

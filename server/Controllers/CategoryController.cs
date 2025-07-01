using Microsoft.AspNetCore.Mvc;

namespace WebAPI_project.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

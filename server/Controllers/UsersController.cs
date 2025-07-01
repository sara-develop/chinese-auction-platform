using Microsoft.AspNetCore.Mvc;

namespace WebAPI_project.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

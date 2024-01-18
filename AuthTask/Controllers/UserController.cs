using Microsoft.AspNetCore.Mvc;


namespace AuthTask.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

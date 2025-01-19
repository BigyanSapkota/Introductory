using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}

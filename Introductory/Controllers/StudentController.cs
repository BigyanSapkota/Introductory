using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

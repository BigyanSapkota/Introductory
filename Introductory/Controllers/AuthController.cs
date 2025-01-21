using Introductory.DAO;
using Introductory.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class AuthController : Controller
    {
        ApplicationDbContext _context;
        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Remove("USER_ID");
            return View();
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginVM vm)
        {
            var user = _context
                        .Users
                        .Where(x => x.Username == vm.Username)
                        .FirstOrDefault();
            if (user == null)
            {
                ViewBag.ErMsg = "Username Doesnt Exists!!";
            }
            else
            {
                if (user.Password != vm.Password)
                {
                    ViewBag.ErMsg = "Password Not Matched!!";
                }
                else
                {
                    // username & password matched
                    HttpContext.Session.SetString("USER_ID", user.UserID.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
    }
}

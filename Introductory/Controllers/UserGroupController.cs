using Introductory.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class UserGroupController : Controller
    {
        ApplicationDbContext _context;
        public UserGroupController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.UserGroup.Where(x => x.IsActive == true).ToList();
            return View(data);
        }

        public IActionResult Setup()
        {  
            return View();
        }


        public IActionResult SetupNew()
        {

            return View();
        }




    }
}

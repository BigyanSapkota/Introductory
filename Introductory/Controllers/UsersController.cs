using Introductory.DAO;
using Introductory.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Introductory.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


       

        //[HttpPost]
        //public JsonResult Save([FromBody] UsersVM model)
        //{ 
        
        //}
    }
}

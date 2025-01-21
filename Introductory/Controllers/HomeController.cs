using Introductory.DAO;
using Introductory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Introductory.Controllers
{
    public class HomeController : BaseController
    {
        ApplicationDbContext _context;   //global object
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            //linq query: 1. Query Syntax   2. Extension Method

            // Add AddRange Remove RemoveRange Count 
            // ToList Where Select OrderBy OrderByDescending ThenBy 
            // First FirstOrDefault Last LastOrDefault

            //Advance: GroupBy Joins Skip Take

            //var ug = _context
            //    .UserGroup
            //    .Where(xyz => xyz.IsActive == false)   //lambda expression
            //    .Select(s => new 
            //    {
            //        id = s.UserGroupID,
            //        name = s.UserGroupName,
            //        code = s.UserGroupCode
            //    })  //lambda expression
            //    .OrderBy(o => o.name)  //lambda expression
            //    .ToList();    //List<UserGroup> 
            //                  //List<Users>


            //ug.UserGroupCode = "SAD";
            //ug.IsActive = false;

            //_context.SaveChanges();



            return View();
        }

        public IActionResult Privacy()
        {
            //Linq query = Language Integrated Query

            List<UserGroup> datas =
                _context
                .UserGroup
                .Where(x => x.IsActive == true)
                .ToList();

            return View(datas);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

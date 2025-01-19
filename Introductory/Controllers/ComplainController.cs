using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainController : Controller
    {
        ApplicationDbContext _context;
        public ComplainController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }





        [HttpPost]
        public JsonResult GetAllData([FromBody] ComplainVM vm)
        {
                List<ComplainVM> dbData = _context
                                    .Complain
                                    .Where(x =>
                                        (string.IsNullOrEmpty(vm.Fullname) || x.Fullname.Contains(vm.Fullname))
                                        && (string.IsNullOrEmpty(vm.ContactNo) || x.ContactNo.Contains(vm.ContactNo))
                                     )
                                    .Select(s => new ComplainVM
                                    {
                                        ComplainId = s.ComplainId.ToInt32(),
                                        Fullname = s.Fullname.ToText(),
                                        Email = s.Email.ToText(),
                                        ContactNo = s.ContactNo.ToText(),
                                        Statement = s.Statement.ToText(),
                                        Address = s.Address.ToText(),
                                        CustomerNo = s.CustomerNo.ToInt32(),
                                        CreatedDate = s.CreatedDate.ToNepaliDate(),
                                        IssueDate = s.IssueDate.ToNepaliDate(),
                                        ComplainTypeID = s.ComplainTypeID.ToInt32(),
                                    })
                                    .ToList();
            return Json(new
            {
                Success = true,
                Data = dbData
            });
        }


    }
}

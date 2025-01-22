using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models;
using Introductory.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainTypeController : Controller
    {
        ApplicationDbContext _context;
        public ComplainTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public JsonResult GetAllData( string ComplainTypeName)
        {
            List<ComplainType> dbData = _context
                                .ComplainType
                                //.Where(x =>
                                //    //(x.ComplainTypeCode==(ComplainTypeCode) || x.ComplainTypeCode.Contains(ComplainTypeCode)) &&
                                //    (string.IsNullOrEmpty(ComplainTypeName) || x.ComplainTypeName.Contains(ComplainTypeName))
                                // )
                                //.Select(s => new ComplainVM
                                //{
                                //    ComplainId = s.ComplainId.ToInt32(),
                                //    Fullname = s.Fullname.ToText(),
                                //    Email = s.Email.ToText(),
                                //    ContactNo = s.ContactNo.ToText(),
                                //    Statement = s.Statement.ToText(),
                                //    Address = s.Address.ToText(),
                                //    CustomerNo = s.CustomerNo.ToInt32(),
                                //    CreatedDate = s.CreatedDate.ToNepaliDate(),
                                //    IssueDate = s.IssueDate.ToNepaliDate(),
                                //    ComplainTypeID = s.ComplainTypeID.ToInt32(),
                                //})
                                .ToList();
            return Json(new
            {
                Success = true,
                Data = dbData
            });
        }
    }
}

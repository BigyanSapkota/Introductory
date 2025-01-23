using Introductory.DAO;
using Introductory.Models.ViewModel;
using Introductory.Models;
using Microsoft.AspNetCore.Mvc;
using Introductory.Helper;

namespace Introductory.Controllers
{
    public class ComplainStatusController : BaseController
    {
        ApplicationDbContext _context;
        public ComplainStatusController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public JsonResult Save([FromBody] ComplainStatusVM vm)
        {
            if (string.IsNullOrEmpty(vm.ComplainStatusName))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Enter Complain Status Name"
                });
            }
            else if (string.IsNullOrEmpty(vm.ComplainStatusCode))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Select Complain Status Code"
                });
            }
            else
            {
                var oldComplain = _context
                                .ComplainStatus
                                .Where(x => x.ComplainStatusCode == vm.ComplainStatusCode && x.CreatedBy == vm.CreatedBy)
                                .FirstOrDefault();
                if (oldComplain != null)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Complain Status Already Exists"
                    });
                }
                else
                {
                    ComplainStatus dbMdl = new ComplainStatus()
                    { 
                        ComplainStatusID = vm.ComplainStatusID,
                        ComplainStatusName = vm.ComplainStatusName.ToText(),
                        ComplainStatusCode = vm.ComplainStatusCode.ToText(),
                        CreatedDate = DateTime.Now,
                        CreatedBy = LoggedInUserID,
                        IsActive = true,
                    };

                    _context.ComplainStatus.Add(dbMdl);

                    _context.SaveChanges();
                    return Json(new
                    {
                        Success = true,
                        Message = "Complain Status Registered Successfully!!!"
                    });
                }
            }
        }



        [HttpGet]
        public JsonResult Delete(int id)
        {
            var oldData = _context
                            .ComplainStatus
                            .Where(x => x.ComplainStatusID == id)
                            .FirstOrDefault();

            if (oldData == null)
            {
                return Json(new
                {
                    Success = false,
                    Messaage = "Data Not Found!"
                });
            }
            else
            {
                oldData.IsActive = false;
                _context.SaveChanges();

                return Json(new
                {
                    Success = true,
                    Messaage = "Complain Status Deleted Successfully!"
                });
            }
        }
    





       [HttpPost]
        public JsonResult GetAllData([FromBody] ComplainStatusVM vm)
        {
              var dbData = _context
                               .ComplainStatus
                                   .Where(x =>
                                        x.IsActive == true
                                        && (string.IsNullOrEmpty(vm.ComplainStatusName) || x.ComplainStatusName.Contains(vm.ComplainStatusName))
                                        && (string.IsNullOrEmpty(vm.ComplainStatusCode) || x.ComplainStatusCode.Contains(vm.ComplainStatusCode))
                                     )
                                    .Select(s => new ComplainStatusVM
                                    {
                                        ComplainStatusID = s.ComplainStatusID.ToInt32(),
                                        ComplainStatusName = s.ComplainStatusName.ToText(),
                                        ComplainStatusCode = s.ComplainStatusCode.ToText(),
                                        CreatedDate = DateTime.Now,
                                        CreatedBy = LoggedInUserID,

                                    })
                                    .ToList();
            return Json(new
            {
                Success = true,
                Data = dbData
            });
        }


        [HttpGet]
        public JsonResult GetComplainByID(int key)
        {
            var dbData = _context
                            .ComplainStatus
                            .Where(x => x.ComplainStatusID == key)
                            .FirstOrDefault();
            if (dbData == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Data Not Found In Database"
                });
            }
            else
            {
                return Json(new
                {
                    Success = true,
                    Data = dbData
                });
            }
        }







    }
}

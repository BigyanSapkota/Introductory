using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models;
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




        [HttpPost]
        public JsonResult Save([FromBody] ComplainVM vm)
        {
            if (vm.ComplainId == 0)
            {
                if (string.IsNullOrEmpty(vm.Fullname))
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Enter Full Name"
                    });
                }
                else if (vm.ComplainTypeID== 0)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Select Complain Type"
                    });
                }
                else
                {
                    var oldComplain = _context
                                    .Complain
                                    .Where(x => x.Fullname == vm.Fullname)
                                    .FirstOrDefault();


                    if (oldComplain == _context
                                    .Complain
                                    .Where(x => x.Fullname == vm.Fullname)
                                    .FirstOrDefault()
                                    )
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Email already Exist for other user"
                        });
                    }
                    else
                    {

                        oldComplain.CustomerNo = vm.CustomerNo.ToInt32();
                        oldComplain.IssueDate= vm.IssueDate.ToEnglishDate();
                        oldComplain.CreatedDate = vm.CreatedDate.ToEnglishDate();
                        oldComplain.Fullname = vm.Fullname.ToText();
                        oldComplain.Email = vm.Email.ToText();
                        oldComplain.ContactNo = vm.ContactNo.ToText();
                        oldComplain.Statement = vm.Statement.ToText();
                        oldComplain.Address = vm.Address.ToText();
                        oldComplain.ComplainTypeID = vm.ComplainTypeID.ToInt32();
                        _context.Complain.Add(oldComplain);

                        _context.SaveChanges();
                        return Json(new
                        {
                            Success = true,
                            Message = "Complain Registered Successfully!!!"
                        });



                    }
                }
            }
            else
            {

                var oldUser = _context
                                        .Complain
                                        .Where(x => x.ComplainId== vm.ComplainId)
                                        .FirstOrDefault();


                Complain dbMdl = new Complain()
                {
                CustomerNo = vm.CustomerNo.ToInt32(),
                IssueDate = vm.IssueDate.ToEnglishDate(),
                CreatedDate = vm.CreatedDate.ToEnglishDate(),
                Fullname = vm.Fullname.ToText(),
                Email = vm.Email.ToText(),
                ContactNo = vm.ContactNo.ToText(),
                Statement = vm.Statement.ToText(),
                Address = vm.Address.ToText(),
                ComplainTypeID = vm.ComplainTypeID.ToInt32()

                  };
                _context.Complain.Add(dbMdl);
                _context.SaveChanges();
                return Json(new
                {
                    Success = true,
                    Message = "Complain edited Successfully!!!"
                });
            }

        }



    }
}

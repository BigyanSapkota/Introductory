using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models;
using Introductory.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace Introductory.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // check if values exists in session
            // if values exists then open the page
            // else redirect to login page

            String sessionValue = HttpContext.Session.GetString("USER_ID");
            if (string.IsNullOrEmpty(sessionValue))
            {
                context.Result = new RedirectResult("/Auth/Login");
            }

            base.OnActionExecuting(context);
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }




        [HttpPost]
        public JsonResult Save([FromBody] UsersVM vm)
        {
            if (string.IsNullOrEmpty(vm.Username))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Enter User Name"
                });
            }
            else if (vm.UserGroupId == 0)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Select User Group Name"
                });
            }
            else if (vm.Password != vm.ConfirmPassword)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Password Not Matched"
                });
            }
            else
            {
                var oldUser = _context
                                .Users
                                .Where(x => x.Username == vm.Username)
                                .FirstOrDefault();
                if (oldUser != null)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Username Already Exists in Database"
                    });
                }
                else
                {
                    Users dbMdl = new Users()
                    {
                        Username = vm.Username.ToText(),
                        Password = vm.Password.ToText(),
                        UserGroupId = vm.UserGroupId.ToInt32(),
                        Fullname = vm.Fullname.ToText(),
                        Address = vm.Address.ToText(),
                        Email = vm.Email.ToText(),
                        ContactNo = vm.ContactNo.ToText(),
                        ValidFrom = vm.ValidFrom.ToEnglishDate(),
                        ValidTo = vm.ValidTo.ToEnglishDate(),
                        IsActive = true
                    };

                    _context.Users.Add(dbMdl);

                    _context.SaveChanges();
                    return Json(new
                    {
                        Success = true,
                        Message = "Users Registered Successfully!!!"
                    });
                }
            }
        }



        [HttpPost]
        public JsonResult GetAllData([FromBody] UsersVM vm)
        {
            List<UsersVM> dbData = _context
                                    .Users
                                    .Where(x => 
                                        x.IsActive == true
                                        && (string.IsNullOrEmpty(vm.Username) || x.Username.Contains(vm.Username))
                                        && (string.IsNullOrEmpty(vm.ContactNo) || x.ContactNo.Contains(vm.ContactNo))   
                                     )
                                    .Select(s => new UsersVM
                                    {
                                        Username = s.Username.ToText(),
                                        Address = s.Address.ToText(),
                                        ContactNo = s.ContactNo.ToText(),
                                        Email = s.Email.ToText(),
                                        Fullname = s.Fullname.ToText(),
                                        UserGroupId = s.UserGroupId.ToInt32(),
                                        UserID = s.UserID.ToInt32(),
                                        ValidFrom = s.ValidFrom.ToNepaliDate(),
                                        ValidTo = s.ValidTo.ToNepaliDate(),
                                    })
                                    .ToList();
            return Json(new
            {
                Success = true,
                Data = dbData
            });
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var oldData = _context
                            .Users
                            .Where(x => x.UserID == id)
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
                    Messaage = "User Deleted Successfully!"
                });
            }
        }
    }
}

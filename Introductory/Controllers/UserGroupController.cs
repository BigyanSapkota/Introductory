using Introductory.DAO;
using Introductory.Models;
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


        public JsonResult SaveData(string name, string code)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Enter User Group Name"
                });
            }
            else if (string.IsNullOrEmpty(code))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Enter User Group Code"
                });
            }
            else
            {

                var duplicateCode = _context
                                        .UserGroup
                                        .Where(x => x.UserGroupCode == code)
                                        .FirstOrDefault();

                if (duplicateCode == null)
                {
                    UserGroup ug;
                    ug = new UserGroup();

                    ug.UserGroupName = name;
                    ug.UserGroupCode = code;
                    ug.CreatedDate = DateTime.Now;
                    ug.IsActive = true;


                    _context.UserGroup.Add(ug);
                    _context.SaveChanges();

                    var obj = new
                    {
                        Success = true,
                        Message = "Data Processed Succesfully"
                    };
                    return Json(obj);
                }
                else
                {
                    return Json(new
                    {
                        Success =false,
                        Message = "User Group Code Already Exist for Another Row"
                    });
                }
            }

        }

        public JsonResult DeleteData(int key)
        {
            var dbData = _context
                            .UserGroup
                            .Where(x => x.UserGroupID == key)
                            .FirstOrDefault();
            if (dbData == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Data not found in Database"
                });
            }
            else
            {
                dbData.IsActive = false;
                _context.SaveChanges();

                return Json(new
                {
                    Success = true,
                    Message = "User Group Info Deleted Successfully"
                });
            }
        }


    }
}

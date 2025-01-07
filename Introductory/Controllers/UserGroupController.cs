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


        public JsonResult SaveData(int id, string name, string code)
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
                if (id == 0)
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
                        Message = "Data Inserted Succesfully"
                    };
                    return Json(obj);
                }
                else
                {
                    // update garne
                    var dbData = _context
                                    .UserGroup
                                    .Where(x => x.UserGroupID == id)
                                    .FirstOrDefault();
                    if (dbData == null)
                    {
                        var obj = new
                        {
                            Success = false,
                            Message = "Data Not Found in Database"
                        };
                        return Json(obj);
                    }
                    else
                    {
                        dbData.UserGroupName = name;
                        dbData.UserGroupCode = code;

                        _context.SaveChanges();
                        var obj = new
                        {
                            Success = true,
                            Message = "Data Modified Successfully"
                        };
                        return Json(obj);
                    }
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


        public JsonResult GetUserGroupByID(int key)
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

using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models;
using Introductory.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainStatusTrackInfoController : Controller
    {

        public ApplicationDbContext _applicationDbContext;

        public ComplainStatusTrackInfoController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save([FromBody] ComplainStatusTrackInfoVM vm)
        {
            if(vm.ComplainID == 0)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Complain info ID is required"
                });
            }
            else if (vm.ComplainStatusID == 0)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Target Status ID is required"
                });
            }
            else if (string.IsNullOrEmpty(vm.Remarks))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Remarks is required."
                });
            }
            else if(vm.CreatedBy == 0)
            {
                return Json(new
                {
                    Success = false,
                    Message = "CreatedBy needs to be specified"
                });
            }
            else if (vm.CreatedDate == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Creation date needs to be specified"
                });
            }
            else
            {
                ComplainStatusTrackInfo complainStatusTrackInfo = new ComplainStatusTrackInfo() {

                    ComplainID = vm.ComplainID,
                    ComplainStatusID = vm.ComplainStatusID,
                    Remarks = vm.Remarks.ToText(),
                    CreatedBy = vm.CreatedBy,
                    CreatedDate = (vm.CreatedDate.ToText()).ToEnglishDate()

                };

                _applicationDbContext.Add(complainStatusTrackInfo);
                _applicationDbContext.SaveChanges();

                var obj = new
                {
                    Success = true,
                    Message = "Data Inserted Succesfully"
                };
                return Json(obj);
            }
        }

        [HttpPost]
        public JsonResult GetAllComplain([FromBody] ComplainStatusTrackInfoVM vm)
        {
            List<ComplainStatusTrackInfoVM> dbData = _applicationDbContext
                                                      .ComplainStatusTrackInfo
                                                      //.Where(x =>
                                                      //         (vm.TargetStatusID == x.TargetStatusID || vm.TargetStatusID.ToText() == null)
                                                      //      && (vm.CreatedDate == x.CreatedDate.ToNepaliDate() || string.IsNullOrEmpty(vm.CreatedDate))
                                                      //)
                                                      .Select(x => new ComplainStatusTrackInfoVM
                                                      {
                                                          ComplainStatusTrackInfoID = x.ComplainStatusTrackInfoID.ToInt32(),
                                                          ComplainID = x.ComplainID.ToInt32(),
                                                          ComplainStatusID = x.ComplainStatusID.ToInt32(),
                                                          Remarks = x.Remarks.ToText(),
                                                          CreatedBy = x.CreatedBy.ToInt32(),
                                                          CreatedDate = x.CreatedDate.ToNepaliDate()
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

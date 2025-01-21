using Introductory.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Introductory.Controllers
{
    public class BaseController : Controller
    {

        protected int LoggedInUserID {
            get 
            {
                return HttpContext.Session.GetString("USER_ID").ToInt32();
            } 
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

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}

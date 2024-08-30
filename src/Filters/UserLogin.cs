using mail_web_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace mail_web_app.Filters
{
    public class UserLogin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string userSection = context.HttpContext.Session.GetString("active-user");

            if (String.IsNullOrEmpty(userSection))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home" },
                    {"Action", "Index"}
                });
            }
            else
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userSection);

                if(user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"controller", "Home" },
                        {"Action", "Index"}
                    });
                }
            }

            base.OnActionExecuted(context);
        }
    }
}

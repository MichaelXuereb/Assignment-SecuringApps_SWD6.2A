using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoppingCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Utility;

namespace WebApplication1.ActionFilters
{
    public class CommentsAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string idDec = Encryption.SymmetricDecrypt(context.ActionArguments["idEnc"].ToString());
                Guid id = Guid.Parse(idDec);

                string email = context.HttpContext.User.Identity.Name;

                ISubmissionsService subService = (ISubmissionsService)context.HttpContext.RequestServices.GetService(typeof(ISubmissionsService));
                var sub = subService.GetSubmission(id);

                if (sub.Email == email || sub.Task.Email == email)
                { }
                else {
                    context.Result = new UnauthorizedObjectResult("Access Denied");
                }

            }
            catch (Exception ex)
            {
                context.Result = new BadRequestObjectResult("Bad Request");
            }
        }
    }
}

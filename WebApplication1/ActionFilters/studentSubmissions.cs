using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoppingCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ActionFilters
{
    public class studentSubmissions : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string email = context.HttpContext.User.Identity.Name;

                ISubmissionsService subService = (ISubmissionsService)context.HttpContext.RequestServices.GetService(typeof(ISubmissionsService));
                var submission = subService.GetSubmissions(email);
                foreach (var sub in submission) { 
                    if (sub.Email != email)
                    {
                        context.Result = new UnauthorizedObjectResult("Access Denied");
                    }
                }
                
            }
            catch (Exception ex)
            {
                context.Result = new BadRequestObjectResult("Bad Request");
            }
        }
    }
}

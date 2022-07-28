using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Abp.Domain.Entities;
using Microsoft.Extensions.Primitives;

namespace API_project.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var keyValue = context.HttpContext.Request.Headers["Rule"];

            if (keyValue == "admin") 
            { 
                return; 
            }
            else 
            {
                context.Result = new BadRequestObjectResult("Invalid Rule");
                return;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}

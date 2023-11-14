using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OEMAP.Api.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            //dto
            var param = context.ActionArguments
                .SingleOrDefault(p => p.Value.ToString().Contains("Dto")).Value;

            if (param != null)
            {
                context.Result = new BadRequestObjectResult($"object is null" +
                    $"Controller : {controller}" +
                    $"Action : {action}");//400
                return;    
            }

            if(!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);//422

        }
    }
}

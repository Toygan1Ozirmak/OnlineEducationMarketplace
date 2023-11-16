using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineEducationMarketplace.Entity.DTOs;

namespace OEMAP.Api.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            // DTO
            var param = context.ActionArguments
                .SingleOrDefault(p => p.Value.GetType().Name.Contains("Dto")).Value;

            if (param == null)
            {
                context.Result = new BadRequestObjectResult($"DTO is null. Controller: {controller}, Action: {action}");
                return;
            }

            if (!(param is UserForRegistrationDto)) // UserForRegistrationDto yerine doğru DTO tipini ekle
            {
                context.Result = new BadRequestObjectResult($"Invalid type for DTO. Controller: {controller}, Action: {action}");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState); // 422
                return;
            }
        }
    }
}

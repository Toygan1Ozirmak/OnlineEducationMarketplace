﻿using Microsoft.AspNetCore.Mvc.Filters;
using OnlineEducationMarketplace.Entity.LogModel;
using OnlineEducationMarketplace.Services.Contracts;

namespace OEMAP.Api.ActionFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _logger;

        public LogFilterAttribute(ILoggerService logger)
        {
                _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInfo(Log("OnaActionexecuting", context.RouteData));
        }

        private string Log(string modelName, RouteData routeData)
        {
            var logDetails = new LogDetails()
            {
                ModelModel = modelName,
                Controller = routeData.Values["controller"],
                Action = routeData.Values["action"]

            };

            if (routeData.Values.Count >= 3)
                logDetails.Id = routeData.Values["Id"];
            return logDetails.ToString();
        }
    }
}

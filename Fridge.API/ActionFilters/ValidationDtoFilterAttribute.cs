using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fridge.API.ActionFilters
{
    public class ValidationDtoFilterAttribute : IActionFilter
    {
        private readonly ILoggerManager logger;

        public ValidationDtoFilterAttribute(ILoggerManager _logger)
        {
            logger = _logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var parameters = context.ActionArguments.Where(x => x.Value.ToString().Contains("Dto")).Select(x => x.Value);
            foreach (var param in parameters)
            {
                if (parameters == null)
                {
                    logger.LogError($"Object sent from client is null. Controller: {controller}, action: {action}");
                    context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");
                    return;
                }
            }

            if (!context.ModelState.IsValid)
            {
                logger.LogError($"Invalid model state for the object. Controller:{controller}, action: {action}");
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}

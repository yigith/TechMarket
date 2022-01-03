using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Filters
{
    public class ValidateBasketAttribute : ActionFilterAttribute
    {

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var basketViewModelService = (IBasketViewModelService)context.HttpContext.RequestServices.GetService(typeof(IBasketViewModelService));

            string basketJson = context.HttpContext.Request.Form["basketJson"];

            if (basketJson != JsonSerializer.Serialize(await basketViewModelService.GetBasketAsync()))
            {
                context.ModelState.AddModelError("", "Your basket has been changed recently. Please review your basket before further process.");
            }

            await next();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace AspNetCoreJwtIdentity.Middlewares
{
    public class WebApiResultNullToEmptyValueAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.HttpContext.Request.Path.HasValue)
            {
                if (context.HttpContext.Request.Path.Value?.ToLower().IndexOf(".inside.") < 0)
                {
                    if (context.Result is FileContentResult || context.Result is EmptyResult)
                    {
                        return;
                    }

                    if (context.Result is ObjectResult)
                    {
                        var objectResult = context.Result as ObjectResult;
                        context.HttpContext.Response.StatusCode = objectResult != null && objectResult.StatusCode.HasValue ? objectResult.StatusCode.Value : 200;
                        var settings = new JsonSerializerSettings()
                        {
                            ContractResolver = new NullToEmptyStringResolver(),
                            DateFormatString = "yyyy-MM-dd HH:mm:ss",

                        };
                        //결과를 wrapping 해야한다면 아래처럼 써야함
                        //context.Result = new JsonResult(new { data = objectResult?.Value }, settings); 
                        context.Result = new JsonResult(objectResult?.Value, settings);
                    }
                    else
                    {
                        context.Result = new ObjectResult(new { data = new { } });
                    }
                }
            }
        }
    }
}

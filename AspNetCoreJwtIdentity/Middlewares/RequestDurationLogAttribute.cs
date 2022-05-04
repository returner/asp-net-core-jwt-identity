using Microsoft.AspNetCore.Mvc.Filters;
using SharedModel.Constants;
using System.Diagnostics;

namespace AspNetCoreJwtIdentity.Middlewares
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class RequestDurationLogAttribute : ActionFilterAttribute
    {
        private static Stopwatch GetTimer(HttpContext context, string type)
        {
            var key = $"__timer__{type}";
            if (context.Items.ContainsKey(key))
            {
                return (Stopwatch)context.Items[key]!;
            }

            var stopWatch = new Stopwatch();
            context.Items[key] = stopWatch;
            return stopWatch;
        }

        private static string BuildLogMessage(string logTypes, string path, Stopwatch stopwatch)
        {
            try
            {
                return stopwatch.ElapsedMilliseconds.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var timer = GetTimer(context.HttpContext, LogTypes.Action);
            timer.Start();
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            var stopwatch = GetTimer(context.HttpContext, LogTypes.Action);
            stopwatch.Stop();

            var loggerObj = context.HttpContext.RequestServices.GetService(typeof(ILogger<RequestDurationLogAttribute>));
            if (loggerObj != null)
            {
                var logger = (ILogger<RequestDurationLogAttribute>)loggerObj;
                var logMessage = BuildLogMessage(LogTypes.Action, context.HttpContext.Request.Path, stopwatch);
                if (!string.IsNullOrWhiteSpace(logMessage))
                {
                    logger.LogInformation(logMessage);
                }
            }
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var stopwatch = GetTimer(context.HttpContext, LogTypes.Result);
            stopwatch.Start();
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
            var stopwatch = GetTimer(context.HttpContext, LogTypes.Result);
            stopwatch.Stop();

            var loggerObj = context.HttpContext.RequestServices.GetService(typeof(ILogger<RequestDurationLogAttribute>));
            if (loggerObj != null)
            {
                var logger = (ILogger<RequestDurationLogAttribute>)loggerObj;
                var logMessage = BuildLogMessage(LogTypes.Result, context.HttpContext.Request.Path, stopwatch);
                if (!string.IsNullOrWhiteSpace(logMessage))
                {
                    logger.LogInformation(logMessage);
                }
            }
        }
    }
}

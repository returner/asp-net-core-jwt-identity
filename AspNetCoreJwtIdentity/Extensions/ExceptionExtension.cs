using Microsoft.AspNetCore.Mvc;
using SharedModel.Contracts.Response;
using SharedModel.Enums;
using System.Net;

namespace AspNetCoreJwtIdentity.Extensions
{
    public static class ExceptionExtension
    {

        public static BadRequestObjectResult BadRequest(this Exception exception, ILogger logger)
        {
            logger.LogError(exception, exception.StackTrace);
            return new BadRequestObjectResult(new ApiErrorResponse(ApiError.Exception, exception.Message)) { StatusCode = (int)HttpStatusCode.BadRequest };
        }
    }
}
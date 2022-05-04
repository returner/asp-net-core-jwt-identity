using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedModel.Contracts.Response;
using SharedModel.Enums;
using System.Net;

namespace AspNetCoreJwtIdentity.Extensions
{
    public static class ApiErrorUnauthorizedExtensions
    {
        public static UnauthorizedObjectResult Unauthorized(this ApiError apiError, ILogger logger, object? parameters = null, string? errorMessage = null)
        {
            logger.LogError($"{apiError} : {ObjectParameterToJsonString(logger, parameters)}");
            return new UnauthorizedObjectResult(new ApiErrorResponse(apiError, errorMessage)) { StatusCode = (int)HttpStatusCode.Unauthorized };
        }
        private static string? ObjectParameterToJsonString(ILogger logger, object? parameters = null)
        {
            if (parameters == null)
            {
                return string.Empty;
            }
            else
            {
                try
                {
                    var jsonString = JsonConvert.SerializeObject(parameters);
                    return jsonString;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "JsonSerializeError");
                    return parameters?.ToString();
                }
            }
        }
    }
}
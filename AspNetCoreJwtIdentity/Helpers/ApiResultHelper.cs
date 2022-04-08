using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedModel.Contracts.Response;
using SharedModel.Enums;
using System.Net;

namespace AspNetCoreJwtIdentity.Helpers
{
    /// <summary>
    /// 오류처리 리턴
    /// </summary>
    public class ApiResultHelper
    {
        /// <summary>
        /// success
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ObjectResult Success(object value)
        {
            return new OkObjectResult(value) { StatusCode = (int)HttpStatusCode.OK };
        }

        /// <summary>
        /// error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="apiError"></param>
        /// <param name="parameters"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static ObjectResult Error(ILogger logger, ApiError apiError, object? parameters = null, string? errorMessage = null)
        {
            logger.LogError($"{apiError} : {ConvertParametersToString(logger, parameters)}");
            return new BadRequestObjectResult(new ApiErrorResponse(apiError, errorMessage)) { StatusCode = (int)HttpStatusCode.BadRequest };
        }

        /// <summary>
        /// exception
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static ObjectResult Exception(ILogger logger, Exception exception)
        {
            logger.LogError(exception, exception.StackTrace);
            return new BadRequestObjectResult(new ApiErrorResponse(ApiError.Exception, exception.Message)) { StatusCode = (int)HttpStatusCode.BadRequest };
        }

        private static string? ConvertParametersToString(ILogger logger, object? parameters = null)
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

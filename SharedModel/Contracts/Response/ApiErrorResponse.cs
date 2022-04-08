using SharedModel.Enums;
using System.Text.RegularExpressions;

namespace SharedModel.Contracts.Response
{
    public class ApiErrorResponse
    {
        public int ErrorCode { get; private set; }
        public string Message { get; private set; }
        public string? Description { get; private set; }
        public string? NotificationMessage { get; private set; }

        public ApiErrorResponse(ApiError apiError, string? descriptionMessage = null)
        {
            Message = ErrorMessageGenerator(apiError);
            ErrorCode = (int)apiError;
            Description = descriptionMessage;
        }

        public ApiErrorResponse(ApiError apiError, int startValue, int endValue)
        {
            Message = ErrorMessageGenerator(apiError);
            ErrorCode = (int)apiError;
            Description = $"between {startValue} and {endValue} required";
        }

        private string ErrorMessageGenerator(ApiError apiError)
        {
            var message = Enum.GetName(typeof(ApiError), apiError);
            var replaced = Regex.Replace(message!, @"(?<!_|^)([A-Z])", "_$1").ToLower();
            return replaced;
        }
    }
}

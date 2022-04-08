using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreJwtIdentity_Test.Extensions
{
    public static class IActionResultExtension
    {
        public static T? Value<T>(this IActionResult result)
        {
            if (result is ObjectResult objectResult)
            {
                var v = objectResult.Value;
                if (v is null)
                    return default;

                return (T)v;
            }

            return default;
        }

        public static int StatusCode(this IActionResult result)
        {
            if (result is ObjectResult objectResult)
            {
                if (objectResult is null)
                { 
                    throw new InvalidOperationException("ObjectResult is null");
                }

                if (objectResult.StatusCode is null)
                {
                    throw new InvalidOperationException("ObjectResult StatusCode is null");
                }

                return objectResult.StatusCode.Value;
            }

            throw new InvalidOperationException("result is not a type of ObjectResult");
        }

        public static Type TypeOfValue<T>(this IActionResult result)
        {
            if (result is ObjectResult objectResult)
            {
                if (objectResult.Value is null)
                {
                    throw new NullReferenceException("objectResult Value is null");
                }

                return objectResult.Value.GetType();
            }

            throw new InvalidOperationException("result is not a type of ObjectResult");
        }

        public static bool IsTypeOfValue<T> (this IActionResult result)
        {
            if (result is ObjectResult objectResult)
            {
                if (objectResult.Value is null)
                {
                    throw new NullReferenceException("objectResult Value is null");
                }

                return objectResult.Value.GetType().Equals(typeof(T));
            }

            throw new InvalidOperationException("result is not a type of ObjectResult");
        }

        public static bool IsSuccess (this IActionResult result)
        {
            if (result is OkObjectResult objectResult)
            {
                return true;
            }

            return false;
        }

        public static bool IsBadRequest (this IActionResult result)
        {
            if (result is BadRequestObjectResult objectResult)
            {
                return true;
            }

            return false;
        }
    }
}

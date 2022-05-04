using AspNetCoreJwtIdentity.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AspNetCoreJwtIdentity.Extensions
{
    public static class ContractResponseExtensions
    {
        public static OkObjectResult Ok(this IContractResponseBase adminResponse)
        {
            return new OkObjectResult(adminResponse) { StatusCode = (int)HttpStatusCode.OK };
        }

        public static OkObjectResult Ok(this IEnumerable<IContractResponseBase> adminResponse)
        {
            return new OkObjectResult(adminResponse) { StatusCode = (int)HttpStatusCode.OK };
        }
    }
}

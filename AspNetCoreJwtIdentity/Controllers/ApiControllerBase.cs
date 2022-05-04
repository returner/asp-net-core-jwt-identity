using AspNetCoreJwtIdentity.Attributes;
using AspNetCoreJwtIdentity.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModel.Contracts.Response;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Net.Mime;

namespace AspNetCoreJwtIdentity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [WebApiResultNullToEmptyValue]
    [Produces(MediaTypeNames.Application.Json)]
    [RequestDurationLog]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, HttpStatusCodeDescription.BadRequest, typeof(ApiErrorResponse))]
    [SwaggerResponse((int)HttpStatusCode.Unauthorized, HttpStatusCodeDescription.Unauthorized)]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, HttpStatusCodeDescription.Forbidden)]

    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        public readonly ILogger<ApiControllerBase> _logger;

        protected ApiControllerBase(IMediator mediator, ILogger<ApiControllerBase> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected async Task<TResponse> QueryAsync<TResponse>(IRequest<TResponse> query)
        {
            return await _mediator.Send(query);
        }

        protected async Task<TResponse> CommandAsync<TResponse>(IRequest<TResponse> command)
        {
            return await _mediator.Send(command);
        }
    }
}

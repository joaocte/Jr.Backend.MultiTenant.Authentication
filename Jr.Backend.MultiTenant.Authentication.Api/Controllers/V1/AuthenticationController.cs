using System.Threading.Tasks;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jr.Backend.MultiTenant.Authentication.Api.Controllers.V1
{
    [Route("api/[controller]/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<GerarTokenCommandResponse> GerarToken([FromServices] IMediator mediator, [FromHeader] GerarTokenCommand query)
        {
            return await mediator.Send(query);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ValidarTokenQueryResponse> ValidarToken([FromServices] IMediator mediator, [FromHeader] ValidarTokenQuery query)
        {
            return await mediator.Send(query);
        }
    }
}
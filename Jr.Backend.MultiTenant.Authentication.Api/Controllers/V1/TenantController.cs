using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class TenantController : ControllerBase
    {
        [HttpGet]
        public async Task<ConsultarTenantQueryResponse> Get([FromServices] IMediator mediator, [FromQuery] ConsultarTenantQuery query)
        {
            return await mediator.Send(query);
        }

        /// <summary>
        /// Cadastra um Novo tenant
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces(typeof(CadastrarTenantCommandResponse))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CadastrarTenantCommandResponse>> Post([FromServices] IMediator mediator,
            [FromBody] CadastrarTenantCommand command)
        {
            var response = await mediator.Send(command);
            return CreatedAtAction("Get", new { ClientId = response?.ClientId, ClientSecret = response?.ClientSecret }, response);
        }
    }
}
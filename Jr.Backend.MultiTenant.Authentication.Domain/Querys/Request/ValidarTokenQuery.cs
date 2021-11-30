using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jror.Backend.MultiTenant.Authentication.Domain.Querys.Request
{
    public class ValidarTokenQuery : IRequest<ValidarTokenQueryResponse>
    {
        [FromHeader]
        public string Token { get; set; }
    }
}
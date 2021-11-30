using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Jror.Backend.MultiTenant.Authentication.Domain.Commands.Request
{
    public class GerarTokenCommand : IRequest<GerarTokenCommandResponse>
    {
        [FromHeader]
        public Guid ClientId { get; set; }

        [FromHeader]
        public Guid ClientSecret { get; set; }
    }
}
using System;

namespace Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response
{
    public class GerarTokenCommandResponse : ApiToken
    {
        public GerarTokenCommandResponse(string token, DateTime expiration) : base(token, expiration)
        {
        }
    }
}
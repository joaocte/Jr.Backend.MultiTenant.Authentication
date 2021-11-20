using System;

namespace Jr.Backend.MultiTenant.Authentication.Domain
{
    public class ApiToken
    {
        public ApiToken(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }

        public string Token { get; private set; }
        public DateTime Expiration { get; private set; }
    }
}
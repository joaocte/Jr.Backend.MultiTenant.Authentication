using System.Text.Json.Serialization;

namespace Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response
{
    public class ValidarTokenQueryResponse
    {
        [JsonConstructor]
        public ValidarTokenQueryResponse(bool isValid)
        {
            IsValid = isValid;
        }

        public bool IsValid { get; set; }
    }
}
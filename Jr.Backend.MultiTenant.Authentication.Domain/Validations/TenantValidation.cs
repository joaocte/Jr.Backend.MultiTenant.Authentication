using FluentValidation;

namespace Jror.Backend.MultiTenant.Authentication.Domain.Validations
{
    public class TenantValidation : AbstractValidator<Tenant>
    {
        public TenantValidation()
        {
            RuleFor(x => x.TenantName)
                .NotEmpty().NotNull().WithMessage("TenantName é obrigatório.");

            RuleFor(x => x.TenantKey)
                .NotEmpty().NotNull().WithMessage("TenantKey é obrigatório");
        }
    }
}
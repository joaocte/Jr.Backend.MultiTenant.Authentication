using AutoMapper;
using Jror.Backend.Libs.Domain.Abstractions.Exceptions;
using Jror.Backend.Libs.Domain.Abstractions.Notifications;
using Jror.Backend.MultiTenant.Authentication.Domain;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Jror.Backend.MultiTenant.Authentication.Application.UseCase.CadastrarTenant
{
    public class CadastrarTenantValidationUseCase : ICadastrarTenantUseCase
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;
        private readonly INotificationContext _notificationContext;
        private readonly ICadastrarTenantUseCase _cadastrarTenantUseCase;

        public CadastrarTenantValidationUseCase(ITenantRepository tenantRepository, IMapper mapper, INotificationContext notificationContext, ICadastrarTenantUseCase cadastrarTenantUseCase)
        {
            this._tenantRepository = tenantRepository;
            this._mapper = mapper;
            this._notificationContext = notificationContext;
            this._cadastrarTenantUseCase = cadastrarTenantUseCase;
        }

        public async Task<CadastrarTenantCommandResponse> ExecuteAsync(CadastrarTenantCommand command, CancellationToken cancellationToken = default)
        {
            var tenantJaCadastrado = await _tenantRepository.ExistsAsync(x =>
                x.TenantName == command.TenantName || x.TenantKey == command.TenantKey, cancellationToken);

            if (tenantJaCadastrado) throw new AlreadyRegisteredException("Tenant já cadastrado");

            var tenantDomain = _mapper.Map<Tenant>(command);

            if (tenantDomain.Invalid)
            {
                _notificationContext.AddNotifications(tenantDomain.ValidationResult);
                return default;
            }

            return await _cadastrarTenantUseCase.ExecuteAsync(command, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tenantRepository?.Dispose();
                _cadastrarTenantUseCase?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
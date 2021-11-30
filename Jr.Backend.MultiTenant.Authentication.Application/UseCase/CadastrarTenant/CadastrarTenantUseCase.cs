using AutoMapper;
using Jror.Backend.Libs.Infrastructure.Data.Shared.Interfaces;
using Jror.Backend.MultiTenant.Authentication.Domain;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Jror.Backend.MultiTenant.Authentication.Application.UseCase.CadastrarTenant
{
    public class CadastrarTenantUseCase : ICadastrarTenantUseCase
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CadastrarTenantUseCase(ITenantRepository tenantRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._tenantRepository = tenantRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<CadastrarTenantCommandResponse> ExecuteAsync(CadastrarTenantCommand command, CancellationToken cancellationToken = default)
        {
            var tenantDomain = _mapper.Map<Tenant>(command);

            var tenantEntity = _mapper.Map<Infrastructure.Entity.Tenant>(tenantDomain);

            var taskAdd = _tenantRepository.AddAsync(tenantEntity, cancellationToken);
            var taskCommit = _unitOfWork.CommitAsync();

            await Task.WhenAll(taskAdd, taskCommit);

            var response = _mapper.Map<CadastrarTenantCommandResponse>(tenantEntity);

            return await Task.FromResult(response);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tenantRepository?.Dispose();
                _unitOfWork?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
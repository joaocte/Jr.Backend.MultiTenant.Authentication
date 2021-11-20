using AutoMapper;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.ObterTenant
{
    public class ObterTenantUseCase : IObterTenantUseCase
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;

        public ObterTenantUseCase(ITenantRepository tenantRepository, IMapper mapper)
        {
            this._tenantRepository = tenantRepository;
            this._mapper = mapper;
        }

        public async Task<ConsultarTenantQueryResponse> ExecuteAsync(ConsultarTenantQuery query, CancellationToken cancellationToken = default)
        {
            var tenant = await _tenantRepository.GetAsync(x => x.ClientId == query.ClientId && x.ClientSecret == query.ClientSecret);

            if (tenant is null)
                throw new NotFiniteNumberException("Não foi encontrado Tenant para os dados informados");

            var response = _mapper.Map<ConsultarTenantQueryResponse>(tenant);

            return await Task.FromResult(response);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tenantRepository?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
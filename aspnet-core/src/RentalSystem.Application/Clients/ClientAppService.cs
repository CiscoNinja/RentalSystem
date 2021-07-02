using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using RentalSystem.Authorization;
using RentalSystem.Clients.Dtos;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Clients
{
    [AbpAuthorize(PermissionNames.Pages_Clients)]
    public class ClientAppService : AsyncCrudAppService<
        Client,
        ClientDto,
        long,
        PagedAndSortedResultRequestDto,
        CreateUpdateClientDto,
        ClientDto>, IClientAppService
    {
        public ClientAppService(IRepository<Client, long> repository)
            : base(repository)
        {

        }

        public override async Task<ClientDto> CreateAsync(CreateUpdateClientDto input)
        {
            CheckCreatePermission();
            var client = ObjectMapper.Map<Client>(input);
            client.TenantId = AbpSession.TenantId;
            await Repository.InsertAsync(client);

            CurrentUnitOfWork.SaveChanges();
            return MapToEntityDto(client);
        }
    }
}



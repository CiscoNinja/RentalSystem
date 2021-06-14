using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
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
    }
}



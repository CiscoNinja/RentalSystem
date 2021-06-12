using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using RentalSystem.Clients.Dtos;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Clients
{
    public class ClientAppService : AsyncCrudAppService<
        Client,
        ClientDto,
        long,
        PagedAndSortedResultRequestDto,
        CreateUpdatelientDto,
        ClientDto>, IClientAppService
    {
        public ClientAppService(IRepository<Client, long> repository)
            : base(repository)
        {

        }
    }
}



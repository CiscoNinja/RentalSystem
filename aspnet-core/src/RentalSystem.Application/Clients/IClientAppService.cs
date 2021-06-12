using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RentalSystem.Clients.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Clients
{
    public interface IClientAppService : IAsyncCrudAppService<
        ClientDto,
        long,
        PagedAndSortedResultRequestDto,
        CreateUpdatelientDto,
        ClientDto>
    {
    }

}

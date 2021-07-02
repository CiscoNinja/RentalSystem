using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using RentalSystem.Authorization;
using RentalSystem.Entities;
using RentalSystem.Miscellaneouss.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Miscellaneouss
{
    [AbpAuthorize(PermissionNames.Pages_Miscellaneous)]
    public class MiscellaneousAppService : AsyncCrudAppService<
        Miscellaneous,
        MiscellaneousDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateMiscellaneousDto,
        MiscellaneousDto>, IMiscellaneousAppService
    {
        public MiscellaneousAppService(IRepository<Miscellaneous, int> repository)
            : base(repository)
        {

        }

        public override async Task<MiscellaneousDto> CreateAsync(CreateUpdateMiscellaneousDto input)
        {
            CheckCreatePermission();
            var miscellaneous = ObjectMapper.Map<Miscellaneous>(input);
            miscellaneous.TenantId = AbpSession.GetTenantId();
            await Repository.InsertAsync(miscellaneous);

            CurrentUnitOfWork.SaveChanges();
            return MapToEntityDto(miscellaneous);
        }
    }
}

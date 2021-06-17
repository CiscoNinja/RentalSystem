using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RentalSystem.Miscellaneouss.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Miscellaneouss
{
    public interface IMiscellaneousAppService : IAsyncCrudAppService<
            MiscellaneousDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateMiscellaneousDto,
            MiscellaneousDto>
    {
    }
}

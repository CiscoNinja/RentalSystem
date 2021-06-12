using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RentalSystem.Facilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Facilities
{

        public interface IFacilityAppService : IAsyncCrudAppService<
       FacilityDto,
       int,
       PagedAndSortedResultRequestDto,
       CreateUpdateFacilityDto,
       FacilityDto>
        {

        }
    
}


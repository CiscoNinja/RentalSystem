using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using RentalSystem.Entities;
using RentalSystem.Facilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Facilities
{

    public class FacilityAppService : AsyncCrudAppService<
   Facility,
   FacilityDto,
   int,
   PagedAndSortedResultRequestDto,
   CreateUpdateFacilityDto,
   FacilityDto>, IFacilityAppService
    {
        public FacilityAppService(IRepository<Facility, int> repository)
            : base(repository)
        {

        }
            }
    
    
}

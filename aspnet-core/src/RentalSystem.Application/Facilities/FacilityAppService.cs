using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using RentalSystem.Authorization;
using RentalSystem.Entities;
using RentalSystem.Facilities.Dtos;
using RentalSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Facilities
{
    [AbpAuthorize(PermissionNames.Pages_Facilities)]
    public class FacilityAppService : AsyncCrudAppService<
   Facility,
   FacilityDto,
   int,
   PagedAndSortedResultRequestDto,
   CreateUpdateFacilityDto,
   FacilityDto>, IFacilityAppService
    {
        //private readonly IRepository<Facility> _faclityRepository;

        public FacilityAppService(IRepository<Facility, int> repository)
            : base(repository)
        {

        }

        public override async Task<FacilityDto> CreateAsync(CreateUpdateFacilityDto input)
        {
            CheckCreatePermission();
            var facility = ObjectMapper.Map<Facility>(input);
            facility.TenantId = AbpSession.TenantId;
            await Repository.InsertAsync(facility);

            CurrentUnitOfWork.SaveChanges();
            return MapToEntityDto(facility);
        }

        public List<KeyValuePair<string, int>> GetFacilityEnumList()
        {
            List<KeyValuePair<string, int>> list = GetEnumList<FacTypeEnum>();

            return list;
        }

        public static List<KeyValuePair<string, int>> GetEnumList<T>()
        {
            var list = new List<KeyValuePair<string, int>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
            }
            return list;
        }
    }
}

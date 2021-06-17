using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using RentalSystem.Authorization;
using RentalSystem.Bookings.Dtos;
using RentalSystem.Clients.Dtos;
using RentalSystem.Entities;
using RentalSystem.Facilities.Dtos;
using RentalSystem.Miscellaneouss.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Bookings
{
    [AbpAuthorize(PermissionNames.Pages_Bookings)]
    public class BookingAppService : AsyncCrudAppService<
        Booking,
        BookingDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookingDto,
        BookingDto>, IBookingAppService
    {
        private readonly IRepository<Client, long> _clientRepository;
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<Miscellaneous> _miscellaneousRepository;

        public BookingAppService(IRepository<Booking, int> repository,
            IRepository<Client, long> clientRepository,
            IRepository<Facility> facilityRepository,
            IRepository<Miscellaneous> miscellaneousRepository
            )
            : base(repository)
        {
            _clientRepository = clientRepository;
            _facilityRepository = facilityRepository;
            _miscellaneousRepository = miscellaneousRepository;
        }

        public async Task<ListResultDto<ClientDto>> GetClients()
        {
            var clients = await _clientRepository.GetAllListAsync();
            return new ListResultDto<ClientDto>(ObjectMapper.Map<List<ClientDto>>(clients));
        }

        public async Task<ListResultDto<FacilityDto>> GetFacilities()
        {
            var facilites = await _facilityRepository.GetAllListAsync();
            return new ListResultDto<FacilityDto>(ObjectMapper.Map<List<FacilityDto>>(facilites));
        }

        public async Task<ListResultDto<MiscellaneousDto>> GetMiscellaneous()
        {
            var miscellaneous = await _facilityRepository.GetAllListAsync();
            return new ListResultDto<MiscellaneousDto>(ObjectMapper.Map<List<MiscellaneousDto>>(miscellaneous));
        }
    }
}

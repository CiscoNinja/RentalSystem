using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RentalSystem.Bookings.Dtos;
using RentalSystem.Clients.Dtos;
using RentalSystem.Facilities.Dtos;
using RentalSystem.Miscellaneouss.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Bookings
{
    public interface IBookingAppService : IAsyncCrudAppService<
        BookingDto, 
        int, 
        PagedAndSortedResultRequestDto,
        CreateUpdateBookingDto,
        BookingDto>
    {
        Task<ListResultDto<ClientDto>> GetClients();
        Task<ListResultDto<FacilityDto>> GetFacilities();
        Task<ListResultDto<MiscellaneousDto>> GetMiscellaneous();
        Task<ListResultDto<BookingListDto>> GetAllList();
        Task<BookingDto> CheckOut(EntityDto<int> input, DateTime CheckOutDate);
        Task<BookingDto> CheckIn(EntityDto<int> input, DateTime CheckInDate);
        Task<PagedResultDto<BookingListDto>> GetAllBookings(PagedAndSortedResultRequestDto input);
    }
}

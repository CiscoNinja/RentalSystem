using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RentalSystem.Bookings.Dtos;
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
    }
}

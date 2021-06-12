using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using RentalSystem.Bookings.Dtos;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Bookings
{
    public class BookingAppService : AsyncCrudAppService<
        Booking,
        BookingDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookingDto,
        BookingDto>, IBookingAppService
    {
        public BookingAppService(IRepository<Booking, int> repository)
            : base(repository)
        {

        }
    }
}

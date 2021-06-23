using AutoMapper;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Bookings.Dtos
{
    public class ClientMapProfile : Profile
    {
        public ClientMapProfile()
        {
            CreateMap<Booking, BookingDto>().ReverseMap();

            CreateMap<CreateUpdateBookingDto, Booking>().ReverseMap();

        }
    }
}

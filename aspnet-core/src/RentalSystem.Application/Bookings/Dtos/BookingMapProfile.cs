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
            CreateMap<Booking, BookingDto>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => src.BookedDates.Split(new[] { ',' })));

            CreateMap<BookingDto, Booking>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => string.Join(',', src.BookedDates)));

            CreateMap<CreateUpdateBookingDto, Booking>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => string.Join(',', src.BookedDates)));

            CreateMap<Booking, CreateUpdateBookingDto>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => src.BookedDates.Split(new[] { ',' })));

        }
    }
}

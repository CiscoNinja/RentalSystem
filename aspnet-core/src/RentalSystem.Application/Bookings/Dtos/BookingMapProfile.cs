using AutoMapper;
using RentalSystem.Entities;
using RentalSystem.Facilities.Dtos;
using RentalSystem.Miscellaneouss.Dto;
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
                .ForMember(x => x.Client, opt => opt.MapFrom(src => src.Client.FullName))
                .ForMember(x => x.Facilities, opt => opt.MapFrom(src => src.FacilityBookings))
                .ForMember(x => x.Miscellaneous, opt => opt.MapFrom(src => src.MiscellaneousBookings
                .Select(x => new MiscellaneousDto
                {
                    Name = x.Miscellaneous.Name,
                    Price = x.Miscellaneous.Price,
                    Quantity = x.QuantityBooked
                }).ToArray()))
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => src.BookedDates.Split(new[] { ',' })));

            CreateMap<BookingDto, Booking>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => string.Join(',', src.BookedDates)));

            CreateMap<CreateUpdateBookingDto, Booking>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => string.Join(',', src.BookedDates))).ReverseMap();

            //CreateMap<Booking, CreateUpdateBookingDto>()
            //    .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => src.BookedDates.Split(new[] { ',' })));

        }
    }
}

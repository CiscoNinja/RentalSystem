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
                .ForMember(dto => dto.Facility, map => map.MapFrom(ent => ent.Facility.Name))
                .ForMember(dto => dto.Client, map => map.MapFrom(ent => ent.Client.Name)).ReverseMap();

            CreateMap<CreateUpdateBookingDto, Booking>().ReverseMap();

        }
    }
}

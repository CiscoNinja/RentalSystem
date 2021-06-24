using AutoMapper;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.FacilityBookings.Dto
{
    public class FacilityBookingMapProfile : Profile
    {
        public FacilityBookingMapProfile()
        {
            CreateMap<FacilityBooking, FacilityBookingDto>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => src.BookedDates.Split(new[] { ',' })));

            CreateMap<FacilityBookingDto, FacilityBooking>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => string.Join(',', src.BookedDates)));
        }
    }
}

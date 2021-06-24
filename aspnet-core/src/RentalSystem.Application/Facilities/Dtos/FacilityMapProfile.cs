using AutoMapper;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Facilities.Dtos
{
    public class ClientMapProfile : Profile
    {
        public ClientMapProfile()
        {
            CreateMap<Facility, FacilityDto>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => src.BookedDates.Split(new[] { ',' })));

            CreateMap<FacilityDto, Facility>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => string.Join(',', src.BookedDates)));

            CreateMap<CreateUpdateFacilityDto, Facility>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => string.Join(',', src.BookedDates)));

            CreateMap<Facility, CreateUpdateFacilityDto>()
                .ForMember(x => x.BookedDates, opt => opt.MapFrom(src => src.BookedDates.Split(new[] { ',' })));
        }
    }
}

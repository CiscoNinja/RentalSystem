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
            CreateMap<Facility, FacilityDto>().ReverseMap();
            CreateMap<CreateUpdateFacilityDto, Facility>().ReverseMap();
        }
    }
}

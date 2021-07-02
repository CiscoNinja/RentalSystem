using AutoMapper;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Miscellaneouss.Dto
{
    public class MiscellaneousMapProfile : Profile
    {
        public MiscellaneousMapProfile()
        {
            CreateMap<Miscellaneous, MiscellaneousDto>().ReverseMap();
            CreateMap<Miscellaneous, MiscellaneousListDto>().ReverseMap();
            CreateMap<CreateUpdateMiscellaneousDto, Miscellaneous>().ReverseMap();
        }
    }
}

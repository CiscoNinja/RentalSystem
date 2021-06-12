using AutoMapper;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Clients.Dtos
{
    public class ClientMapProfile : Profile
    {
        public ClientMapProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<CreateUpdatelientDto, Client>().ReverseMap();
        }
    }
}

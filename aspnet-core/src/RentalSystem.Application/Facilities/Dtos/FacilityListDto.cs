using Abp.Application.Services.Dto;
using RentalSystem.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Facilities.Dtos
{
    public class FacilityListDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public string FacType { get; set; }
        public int NumberOfDaysBooked { get; set; }
        public List<string> BookedDates { get; set; }
    }
}

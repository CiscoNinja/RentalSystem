using RentalSystem.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Facilities
{
        public class CreateUpdateFacilityDto
        {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public FacTypeEnum FacType { get; set; }
        public List<string> BookedDates { get; set; }
        //public bool Isbooked { get; set; }

    }
}
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
    public class FacilityDto : FullAuditedEntityDto<int>
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
    }
}

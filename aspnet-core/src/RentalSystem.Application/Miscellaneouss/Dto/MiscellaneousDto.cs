using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Miscellaneouss.Dto
{
    public class MiscellaneousDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int Quantity { get; set; } = 1;

    }
}

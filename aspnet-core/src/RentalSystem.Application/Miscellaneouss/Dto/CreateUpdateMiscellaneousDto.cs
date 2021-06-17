using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Miscellaneouss.Dto
{
    public class CreateUpdateMiscellaneousDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
    }
}

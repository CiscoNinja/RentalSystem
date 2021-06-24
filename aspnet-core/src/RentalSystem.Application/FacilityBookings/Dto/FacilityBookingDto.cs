using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.FacilityBookings.Dto
{
    public class FacilityBookingDto : EntityDto<int>
    {
        public virtual int BookingId { get; private set; }
        public virtual int FacilityId { get; private set; }
        public List<string> BookedDates { get; set; }
    }
}

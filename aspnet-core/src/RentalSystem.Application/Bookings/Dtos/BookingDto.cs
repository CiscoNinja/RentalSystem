using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using RentalSystem.Entities;
using RentalSystem.Facilities.Dtos;
using RentalSystem.Miscellaneouss.Dto;
using RentalSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Bookings.Dtos
{
    public class BookingDto : FullAuditedEntityDto<int>
    {
        public long ClientId { get; set; }
        public DateTime CheckedInDate { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public double TotalAmount { get; set; }
        public PaymentModeEnum PaymentMode { get; set; }
        public virtual string ClientName { get; set; }
        public virtual Client Client { get; set; }
        public List<string> BookedDates { get; set; }
        public List<FacilityDto> Facilities { get; set; }
        public List<MiscellaneousDto> Miscellaneous { get; set; }
    }
}

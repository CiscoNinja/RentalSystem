using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
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
        public int ClientId { get; set; }
        public DateTime CheckedInDate { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public double TotalAmount { get; set; }
        public PaymentModeEnum PaymentMode { get; set; }
        public virtual string Client { get; set; }
        public List<string> Facilities { get; set; }
        public List<string> Miscellaneous { get; set; }
    }
}

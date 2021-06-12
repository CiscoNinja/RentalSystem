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
        public int FaclityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double AmountPaid { get; set; }
        public PaymentModeEnum PaymentMode { get; set; }
        public virtual string Facility { get; set; }
        public virtual string Client { get; set; }
    }
}

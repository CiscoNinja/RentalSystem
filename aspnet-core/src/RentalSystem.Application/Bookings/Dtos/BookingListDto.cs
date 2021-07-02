using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using RentalSystem.Clients.Dtos;
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
    public class BookingListDto
    {
        public long ClientId { get; set; }
        public DateTime CheckedInDate { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public double TotalAmount { get; set; }
        public string PaymentMode { get; set; }
        public string ClientName { get; set; }
        public ClientListDto Client { get; set; }
        public List<string> BookedDates { get; set; }
        public List<FacilityListDto> Facilities { get; set; }
        public List<MiscellaneousListDto> Miscellaneous { get; set; }
    }
}

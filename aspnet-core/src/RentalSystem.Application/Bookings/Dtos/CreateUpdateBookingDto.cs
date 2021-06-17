using RentalSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Bookings.Dtos
{
     public class CreateUpdateBookingDto
    {
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double AmountPaid { get; set; }
        public PaymentModeEnum PaymentMode { get; set; }
        public List<string> Facilities { get; set; }
        public List<string> Miscellaneous { get; set; }

    }
}

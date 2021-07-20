using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Entities
{
    public class FacilityBooking : Entity
    {
        public virtual int BookingId { get; private set; }
        public virtual int FacilityId { get; private set; }
        public string BookedDates { get; set; }
        public double SalePrice { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Facility Facility { get; set; }
        protected FacilityBooking()
        {

        }

        public FacilityBooking(int bookingid, int facilityid, string bookedDates, double salePrice)
        {
            BookingId = bookingid;
            FacilityId = facilityid;
            BookedDates = bookedDates;
            SalePrice = salePrice;
        }
    }
}

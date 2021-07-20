using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Entities
{
    public class MiscellaneousBooking : Entity
    {
        public virtual int BookingId { get; private set; }
        public virtual int MiscellaneousId { get; private set; }
        public int QuantityBooked { get; set; }
        public double SalePrice { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Miscellaneous Miscellaneous { get; set; }
        protected MiscellaneousBooking()
        {

        }

        public MiscellaneousBooking(int bookingid, int miscellaneousId, int quantityBooked, double salePrice)
        {
            BookingId = bookingid;
            MiscellaneousId = miscellaneousId;
            QuantityBooked = quantityBooked;
            SalePrice = salePrice;
        }
    }
}

using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Entities
{
    public class ClientBooking : Entity
    {
        public virtual int BookingId { get; private set; }
        public virtual long ClientId { get; private set; }
        public virtual Booking Booking { get; set; }
        public virtual Client Client { get; set; }
        protected ClientBooking()
        {

        }

        public ClientBooking(int bookingid, long clientid)
        {
            BookingId = bookingid;
            ClientId = clientid;
        }
    }
}

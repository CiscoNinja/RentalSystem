using Abp.Domain.Entities.Auditing;
using RentalSystem.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Entities
{
    public class Booking : FullAuditedAggregateRoot<int>
    {
        public int ClientId { get; set; }
        public DateTime CheckedInDate { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public double TotalAmount { get; set; }
        public PaymentModeEnum PaymentMode { get; set; }
        public string BookedDates { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<FacilityBooking> FacilityBookings { get; set; }
        public virtual ICollection<MiscellaneousBooking> MiscellaneousBookings { get; set; }

        protected Booking()
        {

        }

        public Booking(int clientId, DateTime checkedInDate,
            DateTime checkedOutDate, double totalAmount, bool checkedIn, bool checkedOut, PaymentModeEnum paymentMode,
            string bookedDates)
            :base()
        {
            ClientId = clientId;
            CheckedInDate = checkedInDate;
            CheckedOutDate = checkedOutDate;
            TotalAmount = totalAmount;
            CheckedIn = checkedIn;
            CheckedOut = checkedOut;
            PaymentMode = paymentMode;
            BookedDates = bookedDates;

            FacilityBookings = new Collection<FacilityBooking>();
            MiscellaneousBookings = new Collection<MiscellaneousBooking>();
        }
    }
}

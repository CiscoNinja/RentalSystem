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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double AmountPaid { get; set; }
        public PaymentModeEnum PaymentMode { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<FacilityBooking> FacilityBookings { get; set; }
        public virtual ICollection<MiscellaneousBooking> MiscellaneousBookings { get; set; }

        protected Booking()
        {

        }

        public Booking(int clientId, DateTime startDate,
            DateTime endDate, double amountPaid, PaymentModeEnum paymentMode,
            Client client)
            :base()
        {
            ClientId = clientId;
            StartDate = startDate;
            EndDate = endDate;
            AmountPaid = amountPaid;
            PaymentMode = paymentMode;
            Client = client;

            FacilityBookings = new Collection<FacilityBooking>();
            MiscellaneousBookings = new Collection<MiscellaneousBooking>();
        }
    }
}

using Abp.Domain.Entities.Auditing;
using RentalSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Entities
{
    public class Booking : FullAuditedAggregateRoot<int>
    {
        public int ClientId { get; set; }
        public int FaclityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double AmountPaid { get; set; }
        public PaymentModeEnum PaymentMode { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual Client Client { get; set; }

        protected Booking()
        {

        }

        public Booking(int clientId, int faclityId, DateTime startDate,
            DateTime endDate, double amountPaid, PaymentModeEnum paymentMode,
            Facility facility, Client client)
            :base()
        {
            ClientId = clientId;
            FaclityId = faclityId;
            StartDate = startDate;
            EndDate = endDate;
            AmountPaid = amountPaid;
            PaymentMode = paymentMode;
            Facility = facility;
            Client = client;
        }
    }
}

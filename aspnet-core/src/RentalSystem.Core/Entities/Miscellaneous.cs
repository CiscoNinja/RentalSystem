using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Entities
{
    public class Miscellaneous : Entity<int>, IMayHaveTenant
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public virtual ICollection<MiscellaneousBooking> MiscellaneousBookings { get; set; }
        public int? TenantId { get; set; }

        protected Miscellaneous()
        {

        }
        public Miscellaneous(string name, double price)
               : base()
        {
            Name = name;
            Price = price;

            MiscellaneousBookings = new Collection<MiscellaneousBooking>();
        }
    }
}

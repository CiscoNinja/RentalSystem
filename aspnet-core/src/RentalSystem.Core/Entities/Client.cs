using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Entities
{
    public class Client : FullAuditedEntity<long>, IMayHaveTenant
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string OrganisationName { get; set; }
        public Address Address { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string FullName => $"{FirstName} {OtherName} {LastName}";
        public int? TenantId { get; set; }
        public virtual ICollection<ClientBooking> ClientBookings { get; set; }

        protected Client()
        {
        }
    public Client(string first, string last, string other, Address address, string email,
            string phone, string nationality)
            //: base()
    {
            FirstName = first;
            LastName = last;
            OtherName = other;
            Address = address;
            Email = email;
            Phone = phone;
            Nationality = nationality;

            ClientBookings = new Collection<ClientBooking>();
    }
}
}


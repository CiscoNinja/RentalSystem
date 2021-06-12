using Abp.Domain.Entities.Auditing;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Entities
{
    public class Client : FullAuditedEntity<long>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string Nationality { get; set; }

        protected Client()
        {
        }
    public Client(string name, string address, string email,
            string phone, string nationality)
            : base()
    {
        Name = name;
        Address = address;
        Email = email;
        Phone = phone;
        Nationality = nationality;

    }
}
}


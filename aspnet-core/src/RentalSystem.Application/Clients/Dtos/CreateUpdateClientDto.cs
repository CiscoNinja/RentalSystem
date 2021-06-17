using RentalSystem.Entities;
using RentalSystem.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Clients.Dtos
{
    public class CreateUpdateClientDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string OrganisationName { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        //[EmailAddress]
        public string Email { get; set; }
        [Required]
        //[Phone]
        public string Phone { get; set; }
        public string Nationality { get; set; }
    }
}
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Clients.Dtos
{
    public class ClientDto : FullAuditedEntityDto<long>
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
    }
}

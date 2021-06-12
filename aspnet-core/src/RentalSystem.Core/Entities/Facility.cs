using Abp.Domain.Entities.Auditing;
using RentalSystem.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Entities
{
    public class Facility : FullAuditedAggregateRoot<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public FacTypeEnum FacType { get; set; }

        protected Facility()
        {

        }
        public Facility(string name, double price, int capacity,
                FacTypeEnum factype)
               : base()
        {
            Name = name;
            Price = price;
            Capacity = capacity;
            FacType = factype;
        }
    }
}

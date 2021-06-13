using Abp.Domain.Entities.Auditing;
using Abp.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalSystem.Entities
{
    public class Address : ValueObject
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String ZipCode { get; set; }

        public Address() { }

        public Address(string line1, string line2, string street, string city, string state, string country, string zipcode)
        {
            Line1 = line1;
            Line2 = line2;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Line1;
            yield return Line2;
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }

        //protected override IEnumerable<object> GetAtomicValues()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
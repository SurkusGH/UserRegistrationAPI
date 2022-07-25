using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationAPI.Models
{
    public class DataSheet
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double PersonalNumber { get; set; }

        public string Email { get; set; }

        //public byte[] Photo { get; set; }

        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public virtual IList<Address> Addresses { get; set; }
    }
}

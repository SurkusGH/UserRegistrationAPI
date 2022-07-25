using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationAPI.Models
{
    public class DataSheet
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double PersonalNumber { get; set; }

        [Required]
        public string Email { get; set; }

        //[Required]
        //public byte[] Photo { get; set; }

        [Required]
        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}

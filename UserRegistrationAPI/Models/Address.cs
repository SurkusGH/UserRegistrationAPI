using System;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Models
{
    public class Address
    {
        public Guid Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string House { get; set; }

        public int Apartanemt { get; set; }
    }
}

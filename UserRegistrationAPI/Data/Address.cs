using System;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Models
{
    public class Address
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int House { get; set; }

        public int Apartament { get; set; }
    }
}

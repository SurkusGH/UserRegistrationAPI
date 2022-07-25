using System;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Models
{
    public class InfoSheet
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public ulong PersonalNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] Photo { get; set; }

        [Required]
        public virtual Address Address { get; set; }
    }
}

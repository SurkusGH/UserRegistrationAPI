using System;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }
       
        [Required]
        public string Password { get; set; }
      
        [Required]
        public string Role { get; set; }

        [Required]
        public InfoSheet InfoSheet { get; set; }
    }
}

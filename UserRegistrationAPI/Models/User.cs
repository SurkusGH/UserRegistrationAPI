using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey(nameof(InfoSheet))]
        public Guid InfoSheetId { get; set; }
        public InfoSheet InfoSheet { get; set; }

    }
}

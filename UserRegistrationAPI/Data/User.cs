using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
       
        public string Password { get; set; }
      
        public string Role { get; set; }

        [ForeignKey(nameof(DataSheet))]
        public Guid DataSheetId { get; set; }
        public DataSheet DataSheet { get; set; }

    }
}

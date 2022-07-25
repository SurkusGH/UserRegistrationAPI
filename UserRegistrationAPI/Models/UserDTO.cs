using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Models
{
    public class UserDTO : CreateUserDTO
    {
        public Guid Id { get; set; }

        public DataSheet DataSheet { get; set; }

        public IList<DataSheetDTO> DataSheets { get; set; }
    }

    public class UpdateUserDTO_Username
    {
        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) Username Is Too Long.")]
        public string Username { get; set; }
    }

    public class UpdateUserDTO_Password
    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }


    public class CreateUserDTO
    {
        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) Username Is Too Long.")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserRegistrationAPI.Data.Data;

namespace UserRegistrationAPI.Core.DTOs
{
    public class UserDTO : CreateUserDTO
    {
        public string Id { get; set; }

        public DataSheet DataSheet { get; set; }
    }

    public class CreateUserDTO
    {
        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) Username Is Too Long.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        private ICollection<string> Roles { get; set; }
    }

    public class UserDTOwithoutId : CreateUserDTO
    {
        public DataSheetDTOwithoutID DataSheet { get; set; }
    }

    public class LoginUserDTO
    {
        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) Username Is Too Long.")]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
    public class UpdateUserDTO_Username
    {
        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) Username Is Too Long.")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
    }

    public class UpdateUserDTO_Password
    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}

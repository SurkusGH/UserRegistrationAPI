using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Models
{
    public class DataSheetDTO : CreateDataSheetDTO
    {
        public Guid Id { get; set; }

        public Address Address { get; set; }

        public IList<AddressDTO> Addresses { get; set; }
    }
    public class CreateDataSheetDTO
    {
        [Required] 
        [StringLength(maximumLength: 25, ErrorMessage = "(!) FirstName Is Too Long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) LastName Is Too Long.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "Your PersonalNumber Has To Be Exactly 11 Digits Long", MinimumLength = 11)]
        public double PersonalNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

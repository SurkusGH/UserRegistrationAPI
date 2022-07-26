using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Models
{
    public class DataSheetDTO : CreateDataSheetDTO
    {
        public Guid Id { get; set; }

        public Address Addresses { get; set; }

        
    }

    public class UpdateDataSheetDTO_FirstName
    {
        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) FirstName Is Too Long.")]
        public string FirstName { get; set; }
    }
    public class UpdateDataSheetDTO_LastName
    {
        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) LastName Is Too Long.")]
        public string LastName { get; set; }
    }
    public class UpdateDataSheetDTO_PersonalNumber
    {
        [Required]
        [StringLength(11, ErrorMessage = "Your PersonalNumber Has To Be Exactly 11 Digits Long", MinimumLength = 11)]
        public string IdentificationNumber { get; set; }
    }
    public class UpdateDataSheetDTO_Email
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
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
        public string IdentificationNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //public IList<CreateAddressDTO> Address { get; set; }
    }
}

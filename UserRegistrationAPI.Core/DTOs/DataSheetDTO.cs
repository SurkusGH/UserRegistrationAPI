using System.ComponentModel.DataAnnotations;
using UserRegistrationAPI.Data.Configurations.Image;
using UserRegistrationAPI.Data.Data;

namespace UserRegistrationAPI.Core.DTOs
{
    public class DataSheetDTO : CreateDataSheetDTO
    {
        public string Id { get; set; }

        public Address Addresses { get; set; }

        public byte[] ImageData { get; set; }
    }

    public class CreateDataSheetDTO
    {

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) FirstName Is Too Long.")]
        public string FirstName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) LastName Is Too Long.")]
        public string LastName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(11, ErrorMessage = "Your PersonalNumber Has To Be Exactly 11 Digits Long", MinimumLength = 11)]
        public string IdentificationNumber { get; set; }

        public CreateAddressDTO Address { get; set; }

        [Required]
        public ImageUploadRequest ImageUpload { get; set; }
    }

    public class DataSheetDTOwithoutID
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdentificationNumber { get; set; }

        public byte[] ImageData { get; set; }

        public AddressDTOwithoutId Address { get; set; }
    }

    public class AddDataSheetDTO_Picture
    {
        public byte[] ImageData { get; set; }
    }

    public class UpdateDataSheetDTO_FirstName
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) FirstName Is Too Long.")]
        public string FirstName { get; set; }
    }
    public class UpdateDataSheetDTO_LastName
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 25, ErrorMessage = "(!) LastName Is Too Long.")]
        public string LastName { get; set; }
    }
    public class UpdateDataSheetDTO_IdentificationNumber
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(11, ErrorMessage = "Your PersonalNumber Has To Be Exactly 11 Digits Long", MinimumLength = 11)]
        public string IdentificationNumber { get; set; }
    }
}

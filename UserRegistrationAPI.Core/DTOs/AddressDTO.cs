using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Core.DTOs
{
    public class AddressDTO : CreateAddressDTO
    {
        public string Id { get; set; }
    }

    public class CreateAddressDTO
    {

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        public string Street { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        public int House { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = false)]
        public int Apartament { get; set; }
    }

    public class AddressDTOwithoutId : CreateAddressDTO
    {

    }

    public class UpdateAddressDTO_City
    {
        [Required]
        public string City { get; set; }
    }
    public class UpdateAddressDTO_Street
    {
        [Required]
        public string Street { get; set; }
    }
    public class UpdateAddressDTO_House
    {
        [Required]
        public int House { get; set; }
    }
    public class UpdateAddressDTO_Apartament
    {
        public int Apartament { get; set; }
    }


}

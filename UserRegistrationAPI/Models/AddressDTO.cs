using System;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Models
{
    public class AddressDTO : CreateAddressDTO
    {
        public Guid Id { get; set; }
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

    public class CreateAddressDTO
    {

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int House { get; set; }

        public int Apartament { get; set; }
    }
}

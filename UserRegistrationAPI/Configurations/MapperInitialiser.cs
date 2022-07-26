using AutoMapper;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Configurations
{
    public class MapperInitialiser : Profile
    {
        public MapperInitialiser()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO_Username>().ReverseMap();
            CreateMap<User, UpdateUserDTO_Password>().ReverseMap();
            CreateMap<User, LoginUserDTO>().ReverseMap();

            CreateMap<DataSheet, DataSheetDTO>().ReverseMap();
            CreateMap<DataSheet, DataSheetDTO>().ReverseMap();
            CreateMap<DataSheet, CreateDataSheetDTO>().ReverseMap();
            CreateMap<DataSheet, UpdateDataSheetDTO_FirstName>().ReverseMap();
            CreateMap<DataSheet, UpdateDataSheetDTO_LastName>().ReverseMap();
            CreateMap<DataSheet, UpdateDataSheetDTO_PersonalNumber>().ReverseMap();
            CreateMap<DataSheet, UpdateDataSheetDTO_Email>().ReverseMap();

            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Address, CreateAddressDTO>().ReverseMap();
            CreateMap<Address, UpdateAddressDTO_City>().ReverseMap();
            CreateMap<Address, UpdateAddressDTO_Street>().ReverseMap();
            CreateMap<Address, UpdateAddressDTO_House>().ReverseMap();
            CreateMap<Address, UpdateAddressDTO_Apartament>().ReverseMap();

        }
    }
}

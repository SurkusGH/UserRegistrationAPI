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

            CreateMap<DataSheet, DataSheetDTO>().ReverseMap();
            CreateMap<DataSheet, DataSheetDTO>().ReverseMap();

            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Address, CreateAddressDTO>().ReverseMap();

        }
    }
}

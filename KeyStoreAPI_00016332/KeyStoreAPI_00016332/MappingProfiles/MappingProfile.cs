using AutoMapper;
using KeyStoreAPI_00016332.DTOs;
using KeyStoreAPI_00016332.Models;

namespace KeyStoreAPI_00016332.MappingProfiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<KeyStoreDto, KeyStore>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}

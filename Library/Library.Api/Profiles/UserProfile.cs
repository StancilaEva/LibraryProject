using AutoMapper;
using Library.Api.DTOs;
using Library.Api.DTOs.UserDTOs;
using Library.Core;

namespace Library.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Address, AddressDTO>()
                .ReverseMap();

            CreateMap<Client, UserDetailDTO>()
                .ForMember(add => add.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(add => add.Username, opt => opt.MapFrom(x => x.Username))
                .ForMember(add => add.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(add => add.Address, opt => opt.MapFrom(x => x.Address));

        }

    }
}

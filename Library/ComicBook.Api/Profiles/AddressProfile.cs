using AutoMapper;
using ComicBook.Api.DTOs;
using Library.Core;

namespace ComicBook.Api.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDTO, Address>()
                .ForMember(add => add.Street, opt => opt.MapFrom(address => address.Street))
                .ForMember(add => add.City, opt => opt.MapFrom(address => address.City))
                .ForMember(add => add.County, opt => opt.MapFrom(address => address.County))
                .ForMember(add => add.Number, opt => opt.MapFrom(address => address.Number))
                .ReverseMap();
        }
    }
}

using AutoMapper;
using Library.Api.DTOs.ReviewDTOs;
using Library.Core;

namespace Library.Api.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>()
                .ForMember(add => add.Rating, opt => opt.MapFrom(x => x.Rating))
                .ForMember(add => add.ReviewText, opt => opt.MapFrom(x => x.ReviewText))
                 .ReverseMap();
        }
    }
}

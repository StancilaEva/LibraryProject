using AutoMapper;
using Library.Api.DTOs.StatsDTO;
using Library.Api.DTOs.StatsDTOs;
using Library.Application.utils;
using Library.Core;

namespace Library.Api.Profiles
{
    public class StatsProfile : Profile
    {
        public StatsProfile()
        {
            CreateMap<KeyValuePair<ComicBook, int>, ComicCountsDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Key.Title))
                .ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Key.Cover))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => GenreConverter.FromEnum(src.Key.Genre)))
                 .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Value));
            CreateMap<KeyValuePair<Genre, int>, GenreStatsDTO>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => GenreConverter.FromEnum(src.Key)))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Value));

            CreateMap<KeyValuePair<string, int>, PublisherStatsDTO>()
                .ForMember(dest => dest.Publishers, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Value));
        }
    }
}

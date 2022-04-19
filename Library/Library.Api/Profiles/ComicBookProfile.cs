using AutoMapper;
using Library.Api.DTOs;
using Library.Application.utils;
using Library.Core;

namespace Library.Api.Profiles
{
    public class ComicBookProfile : Profile
    {
        public ComicBookProfile()
        {
            CreateMap<ComicBookBodyDTO, ComicBook>()
                 .ForMember(add => add.Title, opt => opt.MapFrom(comic => comic.Title))
                 .ForMember(x => x.Publisher, opt => opt.MapFrom(comic => comic.Publisher))
                 .ForMember(x => x.IssueNumber, opt => opt.MapFrom(comic => comic.IssueNumber))
                 .ForMember(x => x.Cover, opt => opt.MapFrom(comic => comic.Cover))
                 .ForMember(x => x.Genre, opt => opt.MapFrom(comic => GenreConverter.FromString(comic.Genre)));
            CreateMap<ComicBook, ComicBookDTO>()
                 .ForMember(add => add.Title, opt => opt.MapFrom(comic => comic.Title))
                 .ForMember(x => x.Publisher, opt => opt.MapFrom(comic => comic.Publisher))
                 .ForMember(x => x.IssueNumber, opt => opt.MapFrom(comic => comic.IssueNumber))
                 .ForMember(x => x.Cover, opt => opt.MapFrom(comic => comic.Cover))
                 .ForMember(x => x.Genre, opt => opt.MapFrom(comic => GenreConverter.FromEnum(comic.Genre)));
        }
    }
}

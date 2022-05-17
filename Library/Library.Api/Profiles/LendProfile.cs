using AutoMapper;
using Library.Api.DTOs.LendDTOs;
using Library.Core;

namespace Library.Api.Profiles
{
    public class LendProfile : Profile
    {
        public LendProfile()
        {
            CreateMap<Lend, LendResultDTO>()
                .ForMember(add => add.ComicBookId, opt => opt.MapFrom(x => x.Book.Id))
                 .ForMember(add => add.ComicBookTitle, opt => opt.MapFrom(x => x.Book.Title))
                  .ForMember(x => x.ComicBookCover, opt => opt.MapFrom(x=>x.Book.Cover))
                  .ForMember(add => add.StartDate, opt => opt.MapFrom(x => x.StartDate))
                   .ForMember(add => add.EndDate, opt => opt.MapFrom(x => x.EndDate))
                   .ForMember(add => add.LendId, opt => opt.MapFrom(x => x.Id))
                   .ForMember(add => add.ClientId, opt => opt.MapFrom(x => x.Client.Id))
                   .ForMember(add=>add.Extended,opt=>opt.MapFrom(x=>x.IsExtended));
            CreateMap<Lend, TimePeriodDTO>()
                .ForMember(add => add.StartDate, opt => opt.MapFrom(x => x.StartDate))
                   .ForMember(add => add.EndDate, opt => opt.MapFrom(x => x.EndDate))
                    .ForMember(add => add.Username, opt => opt.MapFrom(x => x.Client.Username));


        }
    }
}

using AutoMapper;
using OCine.BAL.DTO;
using OCine.BAL.Entity;

namespace Services.AutoMapperProfiles
{
   public class AutoMapperFilmProfile:Profile
    {
        public AutoMapperFilmProfile()
        {
            //MappForGenreFilm
            CreateMap<Films, FilmsDto>()
                .ForMember(fdto => fdto.Genres, opt => opt.MapFrom(entity => entity.Genres));        
            CreateMap<FilmsDto, Films>().ForMember(entity => entity.Genres, opt => opt.MapFrom(dto => dto.Genres));
            //MapforCountrie
            CreateMap<Films, FilmsDto>().ForMember(fdto => fdto.Countries, opt => opt.MapFrom(entity => entity.Country));           
            CreateMap<FilmsDto,Films>().ForMember(entity=> entity.Country, opt => opt.MapFrom(dto => dto.Countries));
            //MapforPremiere
            CreateMap<Films, FilmsDto>().ForMember(dto => dto.Premieres, opt => opt.MapFrom(entity => entity.Premiere));
            CreateMap<FilmsDto, Films>().ForMember(entity => entity.Premiere, opt => opt.MapFrom(dto => dto.Premieres));
            //MapForActor
            CreateMap<Films, FilmsDto>().ForMember(dto => dto.Actors, opt => opt.MapFrom(entity => entity.Actor));
            CreateMap<FilmsDto, Films>().ForMember(entity => entity.Actor, opt => opt.MapFrom(dto => dto.Actors));

            //Страховка
            CreateMap<Films, FilmsDto>();
            CreateMap<FilmsDto, Films>();
            CreateMap<Genres, GenresDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Premiere, PremiereDto>();
            CreateMap<Actor, ActorDto>();
        }
    }
}

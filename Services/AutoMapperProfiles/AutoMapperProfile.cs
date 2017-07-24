using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Data.SqlTypes;
using AutoMapper;

using OCine.BAL.DTO;
using OCine.BAL.Entity;

namespace Services.AutoMapperProfiles
{
   public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            
            
            CreateMap<Films, FilmsDto>();
            CreateMap<FilmsDto, Films>();
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<Premiere, PremiereDto>();
            CreateMap<PremiereDto, Premiere>();
            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();
            CreateMap<SeanceDto, Seance>();
            CreateMap<Seance, SeanceDto>();
            CreateMap<Cinema, CinemaDto>();
            CreateMap<CinemaDto, Cinema>();
            
        }
    }
}

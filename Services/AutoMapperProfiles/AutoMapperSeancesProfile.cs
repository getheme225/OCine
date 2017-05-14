using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OCine.BAL.DTO;
using OCine.BAL.Entity;

namespace Services.AutoMapperProfiles
{
    public class AutoMapperSeancesProfile:Profile
    {
        public AutoMapperSeancesProfile()
        {
            CreateMap<Films, FilmsDto>();
            CreateMap<FilmsDto, Films>();
            CreateMap<Cinema, CinemaDto>();
            CreateMap<CinemaDto, Cinema>();
            CreateMap<Seances, SeancesDto>();
            CreateMap<SeancesDto, Seances>();
        }
    }
}

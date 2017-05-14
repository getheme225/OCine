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
   public class AutoMapperCinemaProfile:Profile
    {
        public AutoMapperCinemaProfile()
        {
            CreateMap<Cinema, CinemaDto>();
            CreateMap<CinemaDto, Cinema>();
        }
    }
}

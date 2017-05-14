using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using AutoMapper;
using CommonComponent.Ninject;
using OCine.BAL.DTO;
using OCine.Common.CommonRepository.Interface;
using OCine.Common.CommonService;
using OCine.BAL.Entity;
using Services.AutoMapperProfiles;


namespace Services
{
   public class FilmsService:BaseService,Interfaces.IFilmServices
   {
       public FilmsService([Named(ContextualBinding.OcineDb)]  IUnitOfWork work, IAutoMapperConfig mapperConfig) : base(work, mapperConfig)
       {
           mapperConfig.AutoMapperConfigure<AutoMapperFilmProfile>();
       }

       
       public IEnumerable<FilmsDto> GetAllFilm()
       {
          return  GetAll<FilmsDto,Films>();
       }
        
       public bool CreateFilms(FilmsDto film)
       {
           var isExist = Exists<Films>(film.ID_film);
           if (isExist) return false;
           else
           { 

               var entity = new Films()
               {
                   ID_film = film.ID_film,
                   Title = film.Title,
                   AgePG = film.AgePG,
                   DirectorProduction = film.DirectorProduction,
                   Duration = film.Duration,
                   TraillerUrl = film.TraillerUrl,
                   Affiche = film.Affiche,
                   Rating = film.Rating,
                   About = film.About,
                   HasInScreening = film.HasInScreening,
                   Actor = Mapper.Map<ICollection<Actor> >(film.Actors),
                   Country = Mapper.Map<ICollection<Country>>(film.Countries),
                   Premiere = Mapper.Map<ICollection<Premiere>>(film.Premieres),
                   Genres = Mapper.Map<ICollection<Genres>>(film.Genres)
               };
               Insert(entity);
               Work.Db.SaveChanges();
               return true;
           }           
        }

       public IEnumerable<FilmsDto> GetAllActualFilms()
       {
           var initialDate = DateTime.Today;
           var indexOfLastMonday = DayOfWeek.Monday - initialDate.DayOfWeek;
           var mondayDate = initialDate.AddDays(indexOfLastMonday);
           return GetAllFilm().Where(f => f.Premieres.ToList().Exists(p => p.PremiereDate > mondayDate));
       }

       public bool UpdateFilm(FilmsDto film)
       {
           var hasExist = Exists<Films>(film.ID_film);
           if (!hasExist) return false;
           else
           {
               Update(Mapper.Map<Films>(film));
               Work.Db.SaveChanges();
               return true;
           }
       }

       public bool DeleteFilm(FilmsDto film)
       {
           var hasExist = Exists<Films>(film.ID_film);
           if (!hasExist) return false;
           else
           {
               Delete(Mapper.Map<Films>(film));
               Work.Db.SaveChanges();
               return true;
           }
       }
   }
}

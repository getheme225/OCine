using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using AutoMapper;
using CommonComponent.Ninject;
using Ninject.Infrastructure.Language;
using OCine.BAL.DTO;
using OCine.Common.CommonRepository.Interface;
using OCine.Common.CommonService;
using OCine.BAL.Entity;
using Services.AutoMapperProfiles;
using Services.Interfaces;


namespace Services
{
    public class FilmsService : BaseService, Interfaces.IFilmServices
    {
       
        public FilmsService([Named(ContextualBinding.OcineDb)] IUnitOfWork work, IAutoMapperConfig mapperConfig) : base(work, mapperConfig)
        {
            mapperConfig.AutoMapperConfigure<AutoMapperProfile>();
        }


        public IEnumerable<FilmsDto> GetAllFilm()
        {
            return GetAll<FilmsDto, Films>();
        }

        public bool CreateFilms(FilmsDto film)
        {
            var existedFilm =
                GetAllFilm().FirstOrDefault(f => AreStringEqual(f.Title,film.Title));
            if (existedFilm != null) return false;
            var entity = new Films
            {

                Title = film.Title,
                AgePG = film.AgePG,
                DirectorProduction = film.DirectorProduction,
                Duration = film.Duration,
                TraillerUrl = film.TraillerUrl,
                Affiche = film.Affiche,
                Rating = film.Rating,
                About = film.About,
                HasInScreening = film.HasInScreening,
                Actor = Mapper.Map<ICollection<Actor>>(film.Actor),
                Premiere = Mapper.Map<ICollection<Premiere>>(film.Premiere),
                Genre = Mapper.Map<ICollection<Genre>>(film.Genre),
                Country = Mapper.Map<ICollection<Country>>(film.Country),
              
            };

            Insert(entity);
            Work.Db.SaveChanges();
            return true;
        }

        public IEnumerable<FilmsDto> GetAllActualFilms()
        {
            var initialDate = DateTime.Today;
            var indexOfLastMonday = DayOfWeek.Monday - initialDate.DayOfWeek;
            var mondayDate = initialDate.AddDays(indexOfLastMonday);
            
            return GetAllFilm().Where(f =>
            {
                return   f.Premiere.ToList().Exists(p => p.PremiereDate >= mondayDate.Date);
            });
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


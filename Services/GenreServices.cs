using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OCine.BAL.DTO;
using OCine.BAL.Entity;
using OCine.Common.CommonRepository.Interface;
using OCine.Common.CommonService;
using Services.AutoMapperProfiles;
using Services.Interfaces;

namespace Services
{
    public class GenreServices:BaseService,IGenreServices
    {
        public GenreServices(IUnitOfWork work, IAutoMapperConfig mapperConfig) : base(work, mapperConfig)
        {
            mapperConfig.AutoMapperConfigure<AutoMapperProfile>();
        }

        public IEnumerable<GenreDto> GetAllGenres()
        {
            return GetAll<GenreDto, Genre>();
        }

        public GenreDto CreateGenre(GenreDto genre)
        {
           
            var entity = new Genre
            {
                GenreName = genre.GenreName,
                Films = Mapper.Map<ICollection<Films>>(genre.FilmsDto)
            };
            Insert(entity);
            Work.Db.SaveChanges();
            return Mapper.Map<GenreDto>(entity);
        }

        public GenreDto UpdateGenre(GenreDto genre)
        {
            var isExist = Exists<Genre>(Mapper.Map<Genre>(genre).ID_Genre);
            if (!isExist) return null;
            Update(Mapper.Map<Genre>(genre));
            Work.Db.SaveChanges();
            return genre;
        }
    }
}

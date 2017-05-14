using System;
using System.Collections.Generic;
using OCine.BAL.DTO;
using OCine.BAL.Entity;
using OCine.Common.CommonRepository.Interface;
using OCine.Common.CommonService;
using Services.AutoMapperProfiles;
using Services.Interfaces;
using AutoMapper;

namespace Services
{
    public class CinemaServices: BaseService, ICinemaServices
    {
        public CinemaServices(IUnitOfWork work, IAutoMapperConfig mapperConfig) : base(work, mapperConfig)
        {
            mapperConfig.AutoMapperConfigure<AutoMapperCinemaProfile>();
        }

        public bool CreateCinema(CinemaDto cinema)
        {
            var isExist = Exists<Cinema>(cinema.ID_Cinema);
            if (isExist) return false;
            else
            {
                var entity = new Cinema()
                {
                    ID_Cinema = cinema.ID_Cinema,
                    CinemaName = cinema.CinemaName,
                    Telephone = cinema.Telephone,
                    Address = cinema.Address,
                    WebSite = cinema.WebSite,
                    Raiting = cinema.Raiting,
                    Image = cinema.Image
                };
                Insert(entity);
                Work.SaveChanges();
                return true;
            }
        }

        public bool UpdateCinema(CinemaDto cinema)
        {
            var isExist = Exists<Cinema>(cinema.ID_Cinema);
            if (!isExist) return false;
            else
            {
                Update(Mapper.Map<Cinema>(cinema));
                Work.SaveChanges();
                return true;
            }
        }

        public bool DeleteCinema(CinemaDto cinema)
        {
            var isExist = Exists<Cinema>(cinema.ID_Cinema);
            if (!isExist) return false;
            else
            {
                Delete(Mapper.Map<Cinema>(cinema));
                Work.SaveChanges();
                return true;
            }
        }

        public IEnumerable<CinemaDto> GetAllCinema()
        {
            return GetAll<CinemaDto, Cinema>();
        }
    }
}

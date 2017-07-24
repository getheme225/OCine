using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommonComponent.Ninject;
using Ninject;
using OCine.BAL.DTO;
using OCine.BAL.Entity;
using OCine.Common.CommonRepository.Interface;
using OCine.Common.CommonService;
using Services.AutoMapperProfiles;
using Services.Interfaces;

namespace Services
{
   public class SeanceServices:BaseService,ISeanceServices
    {
        public SeanceServices([Named(ContextualBinding.OcineDb)] IUnitOfWork work, IAutoMapperConfig mapperConfig) : base(work, mapperConfig)
        {
            mapperConfig.AutoMapperConfigure<AutoMapperProfile>();
        }

        public SeanceDto CreateSeances(SeanceDto seance)
        {
               
                var entity = new Seance
                {
                    PlayingDate = seance.PlayingDate,
                    PlayingTime = seance.PlayingTime,
                    Films = Mapper.Map<Films>(seance.Films),
                    Cinema = Mapper.Map<Cinema>(seance.Cinema),
                    UrlSeances = seance.UrlSeances,
                    Has3D = seance.Has3D
                };
            Insert(entity);
            Work.Db.SaveChanges();
            return Mapper.Map<SeanceDto>(entity);
        }
        

        public IEnumerable<SeanceDto> GetAllSeance()
        {
            return GetAll<SeanceDto, Seance>();
        }

        public IEnumerable<SeanceDto> GetAllNewlestSeances()
        {
            return GetAllSeance().Where(s => s.PlayingDate >= DateTime.Today.Date);
        }

        public bool UpdateSeance(SeanceDto seance)
        {
            var isExist = Exists<Seance>(seance.ID_Seances);
            if (!isExist) return false;
            else
            {
                Update(Mapper.Map<Seance>(seance));
                Work.Db.SaveChanges();
                return true;
            }
        }

        public bool DeleteSeances(SeanceDto seance)
        {
            var isExist = Exists<Seance>(seance.ID_Seances);
            if (!isExist) return false;
            else
            {
                Delete(Mapper.Map<Seance>(seance));
                Work.Db.SaveChanges();
                return true;
            }
        }
    }
}

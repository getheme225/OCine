using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            mapperConfig.AutoMapperConfigure<AutoMapperSeancesProfile>();
        }

        public bool CreateSeances(SeancesDto seance)
        {
            var isExist = Exists<Seances>(seance.ID_Seances);
            if (isExist) return false;
            else
            {
                var entity = new Seances()
                {
                    ID_Seances = seance.ID_Seances,
                    PlayingDate = seance.PlayingDate,
                    PlayingTime = seance.PlayingTime,
                    Cinema = Mapper.Map<Cinema>(seance.Cinema),
                    Films = Mapper.Map<Films>(seance.Film),
                    UrlSeances = seance.UrlSeances
                };
                Insert(entity);
                Work.Db.SaveChanges();
                return true;
            }
        }

        public IEnumerable<SeancesDto> GetAllSeance()
        {
            return GetAll<SeancesDto, Seances>();
        }

        public IEnumerable<SeancesDto> GetAllNewlestSeances()
        {
            return GetAllSeance().Where(s => s.PlayingDate >= DateTime.Today.Date);
        }

        public bool UpdateSeance(SeancesDto seance)
        {
            var isExist = Exists<Seances>(seance.ID_Seances);
            if (!isExist) return false;
            else
            {
                Update(Mapper.Map<Seances>(seance));
                Work.Db.SaveChanges();
                return true;
            }
        }

        public bool DeleteSeances(SeancesDto seance)
        {
            var isExist = Exists<Seances>(seance.ID_Seances);
            if (!isExist) return false;
            else
            {
                Delete(Mapper.Map<Seances>(seance));
                Work.Db.SaveChanges();
                return true;
            }
        }
    }
}

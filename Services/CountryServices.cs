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
   public class CountryServices :BaseService, ICountryServices
    {
        public CountryServices([Named(ContextualBinding.OcineDb)] IUnitOfWork work, IAutoMapperConfig mapperConfig) : base(work, mapperConfig)
        {
            mapperConfig.AutoMapperConfigure<AutoMapperProfile>();
        }

        public IEnumerable<CountryDto> GetAllCountries()
        {
            return GetAll<CountryDto, Country>();
        }

        public CountryDto CreateCountry(CountryDto country)
        {
           
            var entity = new Country
            {
                Country1 = country.Country1,
                Films = Mapper.Map<ICollection<Films>>(country.FilmsDto)
            };
            Insert(entity);
            Work.Db.SaveChanges();
            return Mapper.Map<CountryDto>(entity);
        }

        public CountryDto UpdateCountry(CountryDto country)
        {
            var exist = Exists<Country>(Mapper.Map<CountryDto>(country));
            if (!exist) return null;
            Update(Mapper.Map<Country>(country));
            Work.Db.SaveChanges();
            return country;

        }
    }
}

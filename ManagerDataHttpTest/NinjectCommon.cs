using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject.Modules;
using Ninject;
using OCine.BAL.DTO;

namespace ManagerDataHttpTest
{
   public class NinjectCommon:NinjectModule
    {
            //Bind<IFilmDataHttpProxy>().To<FilmDataHttpProxy>();
            //Bind<IActorDataHttpProxy, ActorDataHttpProxy>();
            //Bind<ISeancesDataHttpProxy, SeancesDataHttpProxy>();
            //Bind<ICinemaDataHttpProxy, CinemaDataHttpProxy>();
            //Bind<IGenreDataProxy, GenreDataProxy>();
            //Bind<ICountryDataHttpProxy, CountryDataHttpProxy>();
        public override void Load()
        {
            //Bind<IFilmDataHttpProxy,FilmDataHttpProxy>();
            //Bind<IActorDataHttpProxy, ActorDataHttpProxy>();
            //Bind<ISeancesDataHttpProxy, SeancesDataHttpProxy>();
            //Bind<ICinemaDataHttpProxy, CinemaDataHttpProxy>();
            //Bind<IGenreDataProxy, GenreDataProxy>();
            //Bind<ICountryDataHttpProxy, CountryDataHttpProxy>();
        }
         
    }
}

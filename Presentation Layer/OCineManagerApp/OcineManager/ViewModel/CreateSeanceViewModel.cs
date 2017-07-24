using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using HttpManagerAccesServices.InterfaceHttp;
using OCine.BAL.DTO;

namespace OCineManagerApps.OcineManager.ViewModel
{
   public class CreateSeanceViewModel:ViewModelBase
   {
       private readonly ISeancesDataHttpProxy _seancesDataHttpProxy;
        public List<SeancesDto> seanceList { get; set; }
       public CinemaDto SelectedCinema;
        public CreateSeanceViewModel(FilmsDto selectedFilms,ISeancesDataHttpProxy seancesDataHttpProxy)
        {
            _seancesDataHttpProxy = seancesDataHttpProxy;

        }
    }
}

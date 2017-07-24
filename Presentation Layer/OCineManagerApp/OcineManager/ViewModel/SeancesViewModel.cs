using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.DATA.Interfaces;
using OCineManagerApps.OcineManager.Helper;
using PropertyChanged;


namespace OCineManagerApps.OcineManager.ViewModel
{
    [ImplementPropertyChanged]
    public class SeancesViewModel:ViewModelBase
    {
        private readonly ISeancesRequest _seancesDataHttp;
        private readonly ICinemaRequest _cinemaData;
        public SeanceDto Seance { get; set; }
        public ObservableCollection<SeanceDto> SeancesList { get; set; }
        public ObservableCollection<CinemaDto> CinemaListForSeance { get; set; }
        public CinemaDto SelectedCinemaForSeances { get; set; }
        public DateTime SelectedDate { get; set; }
        public ObservableCollection<FilmSchedule> FilmScheduleses { get; set; }
        

        public SeancesViewModel(ISeancesRequest seancesDataHttp, ICinemaRequest cinemaData)
        {
            _seancesDataHttp = seancesDataHttp;
            _cinemaData = cinemaData;
            SelectedCinemaForSeances = new CinemaDto();
            SelectedDate = DateTime.Today.Date;
            SeancesList = new ObservableCollection<SeanceDto>();
            ////SeancesList = new ObservableCollection<SeanceDto>(_seancesDataHttp.Allseances());
            //CinemaListForSeance = new ObservableCollection<CinemaDto>();
            //CinemaListForSeance = new ObservableCollection<CinemaDto>(_cinemaData.AllCinema());
            
        }

       
    }
}


using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.DATA.Interfaces;
using PropertyChanged;

namespace OCineManagerApps.OcineManager.ViewModel
{
    [ImplementPropertyChanged]
    public class CinemaViewModel : ViewModelBase
    {
        protected readonly ICinemaRequest CinemaDataHttpProxy;
        #region RelayCommand

        public RelayCommand AddCinema { get; private set; }
        public RelayCommand RefreshCinemaLits { get; private set; }

        #endregion

        #region Public Proprety
       
        public ObservableCollection<CinemaDto> CinemaList { get; private set; }
        public CinemaDto  SelectedCinema { get; set; }
        public string Address { get; set; }

        #endregion

       

        public CinemaViewModel(ICinemaRequest cinemaData)
        {
            #region HttpDataproxy Initiliaze
            CinemaDataHttpProxy = cinemaData;
            #endregion

            #region ObservableCollections Initialize 
            CinemaList = new ObservableCollection<CinemaDto>();
            Refresh();
            SelectedCinema = new CinemaDto();
            #endregion

            #region Command Initialisation
            RefreshCinemaLits = new RelayCommand(Refresh);      
            AddCinema = new RelayCommand(()=> new CreateCinema().Show()); 
                
            #endregion
        }

      private async void Refresh()
        {
            CinemaList = new ObservableCollection<CinemaDto>(await CinemaDataHttpProxy.GetAllItems());
        }

       
    }
}

using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.DATA.Interfaces;
using PropertyChanged;

namespace OCineManagerApps.OcineManager.ViewModel
{
    [ImplementPropertyChanged]
    public class FilmsViewModel :ViewModelBase
    {
       /// <summary>
       /// Интерфейс для запроса
       /// </summary>
        protected readonly IFilmsRequest FilmDataHttpProxy;

        /// <summary>
        /// Экземпляр фильма
        /// </summary>
        public FilmsDto FilmVm { get; set; }

        /// <summary>
        /// Список фильмов 
        /// </summary>
        public ObservableCollection<FilmsDto> FilmsList { get; set; }      

        /// <summary>
        /// Обработка кнопки для редактирования фильма
        /// </summary>
        //public RelayCommand EditFilm { get; private set; }

        /// <summary>
        /// Обработкчить кнопки для добавления сеансов к фильма "Переход к окне  управления сеансов
        /// </summary>
        public RelayCommand AddToSeances { get; private set; }

        /// <summary>
        /// Обрабаботчик кнопки добавления нового фильма 
        /// </summary>
        public RelayCommand AddNewFilm { get; private set; }

        public RelayCommand ReFreshCommand { get; private set; }
        
        public FilmsViewModel(IFilmsRequest filmDataHttpProxy)
        {
            FilmDataHttpProxy = filmDataHttpProxy;
            AddNewFilm = new RelayCommand(() => new CreateFilm().Show());
            FilmsList = new ObservableCollection<FilmsDto>();
            AllFilmFromApi();
            ReFreshCommand = new RelayCommand(AllFilmFromApi);
            AddToSeances = new RelayCommand(() => new AddSeances().Show());
        }


        public async void AllFilmFromApi()
        {
            try
            {
                var result = await FilmDataHttpProxy.GetAllItems();
                FilmsList = new ObservableCollection<FilmsDto>(result);
            }
            catch(Exception ex)
            {
             //ToDo need Exception For getting All Films   
            }

        }
    }
}

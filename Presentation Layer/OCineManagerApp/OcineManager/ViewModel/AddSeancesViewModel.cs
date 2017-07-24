using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.DATA.Interfaces;
using OCineManagerApps.OcineManager.Helper;

namespace OCineManagerApps.OcineManager.ViewModel
{
   public class AddSeancesViewModel :FilmsViewModel
   {
        /// <summary>
        /// Интерфейс для работы запрос get/post Сеансов
        /// </summary>
        private readonly ISeancesRequest _seancesDataHttp;

        /// <summary>
        /// Интерфейс для работы запрос get/post кинотеар
        /// </summary>
        private readonly ICinemaRequest _cinemaDataHttpProxy;

        /// <summary>
        /// Список кинотеатров
        /// </summary>
       public ObservableCollection<CinemaDto> CinemaList { get; set; }
        
        /// <summary>
        /// Список сеансов
        /// </summary>
       public ObservableCollection<SeanceDto> SeancesList { get; set; }

        /// <summary>
        /// Дата сеанса
        /// </summary>
       public DateTime SelectedDate { get; set; }

        /// <summary>
        /// Список фильмов которые ещё не в показе
        /// </summary>
       public ObservableCollection<FilmsDto> FilmNotInScreenList => new ObservableCollection<FilmsDto>(FilmsList.Where(f => f.HasInScreening != null && f.HasInScreening.Value == false)); 

        /// <summary>
        /// Выбраный фильмь для добавления к сеансе
        /// </summary>
       public FilmsDto SelectedFilm { get; set; }

        /// <summary>
        /// Кинотеатра показа сеанса
        /// </summary>
       public CinemaDto SelectedCinema { get; set; }

        /// <summary>
        /// Время показа
        /// </summary>
       public RelayCommand AddNewSeancesTime { get; set; }

        /// <summary>
        /// Обработчик кнопки отправки на сервену 
        /// </summary>
       public RelayCommand<IClosable> Submit { get; set; }

        /// <summary>
        /// Конструктор AddSeancesViewModel
        /// </summary>
        /// <param name="filmDataHttpProxy"></param>
        /// <param name="seancesDataHttp"></param>
        /// <param name="cinemaDataHttpProxy"></param>
        public AddSeancesViewModel(IFilmsRequest filmDataHttpProxy, ISeancesRequest seancesDataHttp, ICinemaRequest cinemaDataHttpProxy) : base(filmDataHttpProxy)
        {
            _seancesDataHttp = seancesDataHttp;
            _cinemaDataHttpProxy = cinemaDataHttpProxy;
            SeancesList = new ObservableCollection<SeanceDto>();
            CinemaList = new ObservableCollection<CinemaDto>();
            InitialiseList();
            AddNewSeancesTime = new RelayCommand(AddSeancesTimeTextBox);
            Submit = new RelayCommand<IClosable>(SubmitSeances);
            
        }

        /// <summary>
        /// Получения асинхроно список кинотеартров 
        /// </summary>
       private async void InitialiseList()
       {
           CinemaList = new ObservableCollection<CinemaDto>(await _cinemaDataHttpProxy.GetAllItems());
       }
       private void AddSeancesTimeTextBox()
       {
            SelectedFilm.HasInScreening = true;
            SeancesList.Add(new SeanceDto()
           {
               Films = SelectedFilm,
               Cinema = SelectedCinema,
               PlayingDate = SelectedDate.Date,            
            });
       }

       public async void SubmitSeances(IClosable windows)
       {
           try
           {
               
                
               if (SeancesList.Count == 0) return;
               foreach (var seance in SeancesList)
               {
                    
                 await _seancesDataHttp.CreateItem(seance);
               }

                
               ReFreshCommand.RaiseCanExecuteChanged();
               windows?.Close();
           }
           catch (Exception e)
           {
               MessageBox.Show($"hoops {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
           }
       }
   }
}

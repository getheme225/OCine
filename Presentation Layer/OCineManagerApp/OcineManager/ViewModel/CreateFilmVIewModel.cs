using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.DATA.Interfaces;
using OCineManagerApps.OcineManager.Helper;
using PropertyChanged;

namespace OCineManagerApps.OcineManager.ViewModel
{
    [ImplementPropertyChanged]
    public class CreateFilmVIewModel : ViewModelBase
    {

        #region HttpProxyInterface
        /// <summary>
        /// Интерфейс для работы запрос get/post фильм 
        /// </summary>
        private readonly IFilmsRequest _filmDataHttpProxy;

        /// <summary>
        /// Интерфейс для работы запрос get/post Актёр
        /// </summary>
        private readonly IActorRequest _actorDataHttpProxy;

        /// <summary>
        /// Интерфейс для работы запрос get/post Страна
        /// </summary>
        private readonly ICountryRequest _countryDataHttpProxy;

        /// <summary>
        /// Интерфейс для работы запрос get/post Жанр 
        /// </summary>
        private readonly IGenreRequest _genreDataProxy;

        #endregion

        #region Public Proprety 

        #region Command
        public RelayCommand AddCountryUserControlCommand { get; private set; }
        public RelayCommand AddActorUserControlCommand { get; private set; }
        public RelayCommand AddPremiereUserControlCommand { get; private set; }
        public RelayCommand AddGenreUserControlCommand { get; private set; }
        public RelayCommand BrowseImageCommand { get; private set; }
        public RelayCommand<IClosable> SubmitFilm { get; private set; }
        #endregion

        #region 
        public ObservableCollection<CountryDto> AddCountryUserControlCollection { get; set; }
        public ObservableCollection<ActorDto> AddActorUserControlCollection { get; set; }
        public ObservableCollection<PremiereDto> AddPremiereUserControlsCollection { get; set; }
        public ObservableCollection<GenreDto> AddGenresUserControlsCollection { get; set; }

        #endregion

        #region Public Proprety
        public BitmapImage AfficheImage { get; set; }
        public FilmsDto Films { get; set; }
        public string About { get; set; }
        private  ICollection<ActorDto> _actorList;
        private ICollection<CountryDto> _countryList;
        private ICollection<GenreDto> _genresList;
        #endregion
        #endregion

        public CreateFilmVIewModel(IFilmsRequest filmDataHttpProxy, IActorRequest actorDataHttpProxy, ICountryRequest countryDataHttpProxy, IGenreRequest genreDataProxy) 
        {


            #region Proxy Initialize


            _actorDataHttpProxy = actorDataHttpProxy;
            _countryDataHttpProxy = countryDataHttpProxy;
            _genreDataProxy = genreDataProxy;
            _filmDataHttpProxy = filmDataHttpProxy;

            #endregion

            #region Initilize List
            ListInitialisation();
            #endregion

            #region GetDataFromServeur



            #endregion

            #region ObservableCollectionInitalize

            AddCountryUserControlCollection = new ObservableCollection<CountryDto>();
            AddActorUserControlCollection = new ObservableCollection<ActorDto>();
            AddPremiereUserControlsCollection = new ObservableCollection<PremiereDto>();
            AddGenresUserControlsCollection = new ObservableCollection<GenreDto>();
            #endregion

            #region Commande Intialize 

            AddCountryUserControlCommand = new RelayCommand(CreateCountryUserControls);
            AddActorUserControlCommand = new RelayCommand(CreateActorUserControls);
            AddPremiereUserControlCommand = new RelayCommand(CreatePremierUserControls);
            AddGenreUserControlCommand = new RelayCommand(CreateGenreUserContrlos);
            BrowseImageCommand = new RelayCommand(OpenFileDialog);
            SubmitFilm = new RelayCommand<IClosable>(PullServeur);

            #endregion

            #region Initialize Film
            Films = new FilmsDto()
            {
                Actor = new Collection<ActorDto>(),
                Country = new Collection<CountryDto>(),
                Genre = new Collection<GenreDto>(),
                Premiere = new Collection<PremiereDto>()
            };
            #endregion

        }
        /// <summary>
        ///  Инициалищация списков актёров, Жанра,стран
        /// </summary>
        private async void ListInitialisation()
        {
            _actorList = await _actorDataHttpProxy.GetAllItems();
            _genresList = await _genreDataProxy.GetAllItems();
            _countryList = await _countryDataHttpProxy.GetAllItems();
        }
       
        #region ActorListAdder,CountryListAdder,GenreListAdder,PremierListAdder
        /// <summary>
        /// Дабоваить список 
        /// </summary>
        private async void AddActorsToFilm()
        {

            foreach (var actorAdded in AddActorUserControlCollection)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(actorAdded?.Name)) continue;
                    var actor =
                        _actorList.FirstOrDefault(
                            a =>
                                !(string.IsNullOrEmpty(a.Name)) &&
                                a.Name.Equals(actorAdded.Name, StringComparison.CurrentCultureIgnoreCase));
                    if (actor == null)
                    {
                        Films.Actor.Add(await _actorDataHttpProxy.CreateItem(actorAdded));
                        continue;
                    }

                    Films.Actor.Add(actor);
                }
                catch
                {
                    // ToDo Обработать ошибки
                }
            }
        }
        /// <summary>
        /// Дабоваить Страну 
        /// </summary>
        private async void AddCountryTofilm()
        {
            foreach (var countryAdded in AddCountryUserControlCollection)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(countryAdded?.Country1)) continue;
                    var country =
                        _countryList.FirstOrDefault(
                            a =>
                                !(string.IsNullOrEmpty(a.Country1)) &&
                                a.Country1.Equals(countryAdded.Country1, StringComparison.CurrentCultureIgnoreCase));
                    if (country == null)
                    {
                        Films.Country.Add(await _countryDataHttpProxy.CreateItem(countryAdded));
                        continue;
                    }
                    Films.Country.Add(country);
                }
                catch
                {
                    // ToDo AddCountryTofilm Exception
                }
            }
        }

        /// <summary>
        /// Дабоваить прьемеры 
        /// </summary>
        private void AddPremieres()
        {
            foreach (var premier in AddPremiereUserControlsCollection)
            {
                if (premier?.PremiereDate == null | string.IsNullOrWhiteSpace(premier?.CountryPremieres)) continue;
                Films.Premiere.Add(new PremiereDto()
                {
                    PremiereDate = premier.PremiereDate,
                    CountryPremieres = premier.CountryPremieres
                });
            }
        }

        /// <summary>
        /// Дабоваить Жанр 
        /// </summary>
        private async void AddGenres()
        {
            foreach (var genreAdded in AddGenresUserControlsCollection)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(genreAdded?.GenreName)) continue;
                    var genre =
                        _genresList.FirstOrDefault(
                            a =>
                                (string.IsNullOrEmpty(a.GenreName)) &&
                                a.GenreName.Equals(genreAdded.GenreName, StringComparison.CurrentCultureIgnoreCase));
                    if (genre == null)
                    {

                        Films.Genre.Add(await _genreDataProxy.CreateItem(genreAdded));
                        continue;
                    }
                    genre.FilmsDto?.Add(Films);
                    Films.Genre.Add(genre);
                }
                catch
                {
                    //ToDo AddGenres Exception
                }
            }
        }

        #endregion

        /// <summary>
        /// Метод для отправки данные на сервере
        /// </summary>
        /// <param name="windows"></param>
        private void PullServeur(IClosable windows)
        {

            Films.About = About;
            Films.Affiche = AfficheInByte;
            Films.HasInScreening = false;
            AddActorsToFilm();
            AddCountryTofilm();
            AddPremieres();
            AddGenres();
            try
            {
                _filmDataHttpProxy.CreateItem(Films);
            }
            catch (Exception)
            {
                // ToDo Need Exception For Pulling Film
            }
            
            windows.Close();
        }

        #region ImageFactory
        public void OpenFileDialog()
        {
            var dialog = new OpenFileDialog { Filter = @"Image Files|*.jpg;*.jpeg" };
            dialog.ShowDialog();

            if (dialog.FileName != null)
                AfficheImage = new BitmapImage(new Uri(dialog.FileName, UriKind.Absolute));
            AfficheInByte = ImageConverter.ImageBytes(dialog.FileName);
        }

        private byte[] AfficheInByte { get; set; }


        #endregion

        #region UserControlFactory
        /// <summary>
        /// Получить данные о прьемере
        /// </summary>
        private void CreatePremierUserControls()
        {
            AddPremiereUserControlsCollection.Add(new PremiereDto());
        }

        /// <summary>
        /// получить данные с userControls добавления актёра
        /// </summary>
        private void CreateActorUserControls()
        {
            AddActorUserControlCollection.Add(new ActorDto());

        }
       
        /// <summary>
        /// получить данные с userControls добавления Жанр
        /// </summary>
        private void CreateGenreUserContrlos()
        {
            AddGenresUserControlsCollection.Add(new GenreDto());
        }

        /// <summary>
        /// получить данные с userControls добавления Страна
        /// </summary>
        private void CreateCountryUserControls()
        {
            AddCountryUserControlCollection.Add(new CountryDto());
        }


        #endregion

    
    }
}





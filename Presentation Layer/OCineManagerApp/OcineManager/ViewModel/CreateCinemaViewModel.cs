using System;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Command;
using Microsoft.Maps.MapControl.WPF;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.BingMapsService;
using OCineManagerApps.OcineManager.DATA.Interfaces;
using OCineManagerApps.OcineManager.Helper;
using PropertyChanged;

namespace OCineManagerApps.OcineManager.ViewModel
{
    [ImplementPropertyChanged]
    public class CreateCinemaViewModel : CinemaViewModel
    {
        /// <summary>
        /// Интерфейс для работы запрос get/post Сеансов
        /// </summary>
        private readonly ICinemaRequest _cinemaData;

        /// <summary>
        /// экземпляр Кинотеар для создания 
        /// </summary>
        public CinemaDto Cinema { get; set; }

        /// <summary>
        /// Аддресс кинотеартра
        /// </summary>
        public string AddressCinema { get; set; }

        /// <summary>
        /// Картинка в байт
        /// </summary>
        public byte[] AfficheInByte { get; set; }

        /// <summary>
        /// Визуальная картинка
        /// </summary>
        public BitmapImage AfficheImage { get; set; }

        /// <summary>
        /// Обработчик кнопки Browse Image
        /// </summary>
        public RelayCommand BrowseImageCommand { get; set; }

        /// <summary>
        /// Ответ от Bing Service
        /// </summary>
        public GeocodeResponse GeocodeResponse { get; set; }

        /// <summary>
        /// Обработчик Для кнопки найти местоположения на карте
        /// </summary>
        public RelayCommand<string> FindOnMapCommand { get; set; }

        /// <summary>
        /// Обработчик отправка на сервере 
        /// </summary>
        public RelayCommand <IClosable> Submit { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="cinemaData"></param>
        public CreateCinemaViewModel(ICinemaRequest cinemaData) : base(cinemaData)
        {
            Cinema = new CinemaDto();
            _cinemaData = cinemaData;
            FindOnMapCommand = new RelayCommand<string>(GetAddress);
            BrowseImageCommand = new RelayCommand(OpenFileDialog);
            Submit = new RelayCommand<IClosable>(SubmitCinema);
            AddressCinema = "Парижской Коммуны, 58, Иваново, Ивановская область, 153003";
            GetAddress(AddressCinema);
        }
        
        /// <summary>
        /// Запрос на получения координаты кинотеатра
        /// </summary>
        /// <param name="address"></param>
        private async  void GetAddress(string address)
        {
            using (GeocodeServiceClient client = new GeocodeServiceClient("CustomBinding_IGeocodeService"))
            {
                var request = new GeocodeRequest
                {
                    Credentials = new Credentials()
                    {
                        ApplicationId =
                            (App.Current.Resources["MyCredentials"] as ApplicationIdCredentialsProvider).ApplicationId
                    },
                    Culture = "ru",
                    Query = AddressCinema,
                    
                };
                var filters = new ConfidenceFilter[1];
                filters[0] = new ConfidenceFilter {MinimumConfidence = Confidence.High};

                var geocodeOptions = new GeocodeOptions {Filters = filters};
                request.Options = geocodeOptions;
                GeocodeResponse = await client.GeocodeAsync(request);
            }

        }

        /// <summary>
        /// Открыть файловое диалоговое окно
        /// </summary>
        public void OpenFileDialog()
        {
            var dialog = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg" };
            dialog.ShowDialog();

            if (dialog.FileName != null)
                AfficheImage = new BitmapImage(new Uri(dialog.FileName, UriKind.Absolute));
            AfficheInByte = ImageConverter.ImageBytes(dialog.FileName);
        }
        
        /// <summary>
        /// Отправить на сервер новый кинотеатра
        /// </summary>
        /// <param name="windows"></param>
        public async void SubmitCinema(IClosable windows)
        {
            try
            {
                Cinema.Address_Longitude = GeocodeResponse.Results[0].Locations[0].Longitude;
                Cinema.Address_Latitude = GeocodeResponse.Results[0].Locations[0].Latitude;
                Cinema.Image = AfficheInByte;
                var addedCinema = await _cinemaData.CreateItem(Cinema);
                CinemaList.Add(addedCinema);
                windows.Close();
            }
            catch (Exception ex)
            {
                // ToDo EXception For CreateCinemaViewModel
            }

        }
        
    }
}

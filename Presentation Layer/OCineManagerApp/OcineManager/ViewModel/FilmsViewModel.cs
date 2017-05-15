using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.HttpClient.Interface;
using PropertyChanged;

namespace OCineManagerApps.OcineManager.ViewModel
{
    [ImplementPropertyChanged]
    public class FilmsViewModel
    {
        private readonly IWebApiConnection _webApi;

        public FilmsViewModel(IWebApiConnection webApi)
        {
            _webApi = webApi;
            GetFilmList();
        }

        public FilmsDto FilmVm { get; set; }
        public ObservableCollection<FilmsDto> FilmsList { get; private set; }

        private async void GetFilmList()
        {
            try
            {
                HttpResponseMessage result = await _webApi.Client.GetAsync("api/film");
                result.EnsureSuccessStatusCode();
                var list = await result.Content.ReadAsAsync<IEnumerable<FilmsDto>>();
                FilmsList = new ObservableCollection<FilmsDto>(list);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

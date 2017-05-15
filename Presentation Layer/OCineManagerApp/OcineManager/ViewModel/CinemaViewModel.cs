using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.HttpClient.Interface;
using PropertyChanged;

namespace OCineManagerApps.OcineManager.ViewModel
{
    [ImplementPropertyChanged]
    public class CinemaViewModel
    {
        private readonly IWebApiConnection _webApi;

        public CinemaViewModel(IWebApiConnection webApi)
        {
            _webApi = webApi;
            GetCinemaList();
        }
        public CinemaDto Cinema { get; set; }
        public ObservableCollection<CinemaDto> CinemaList { get; private set; }

        private async void GetCinemaList()
        {
            try
            {
                var result = await _webApi.Client.GetAsync("api/Cinema");
                result.EnsureSuccessStatusCode();
                var list = await result.Content.ReadAsAsync<IEnumerable<CinemaDto>>();
                CinemaList = new ObservableCollection<CinemaDto>(list.ToList());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

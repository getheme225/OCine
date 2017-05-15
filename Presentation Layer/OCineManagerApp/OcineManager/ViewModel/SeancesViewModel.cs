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

namespace OCineManagerApps.OcineManager.ViewModel
{
    public class SeancesViewModel
    {
        private readonly IWebApiConnection _webApi;

        public SeancesViewModel(IWebApiConnection webApi)
        {
            _webApi = webApi;
            GetSeancesList();
        }
        public SeancesDto Seance { get; set; }
        public ObservableCollection<SeancesDto> SeancesList { get; private set; }

        private async void GetSeancesList()
        {
            try
            {
                var result = await _webApi.Client.GetAsync("api/Cinema");
                result.EnsureSuccessStatusCode();
                var list = await result.Content.ReadAsAsync<IEnumerable<SeancesDto>>();
                SeancesList = new ObservableCollection<SeancesDto>(list);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

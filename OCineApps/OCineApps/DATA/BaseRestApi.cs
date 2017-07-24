using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OCineApps.DATA
{
   public abstract class BaseRestApi <T> where T: class, new ()
   {
        /// <summary>
        /// Http Client
        /// </summary>
       private readonly HttpClient _client;

        /// <summary>
        /// Начальный Адресс WebAPI
        /// </summary>
       private const string BaseApiUri = "http://ocinewebapi2.azurewebsites.net/api/";

       private string _subPathUri { get; }

       protected BaseRestApi(string uri="")
        {  
            this._subPathUri = uri;
            _client = new HttpClient();
        }

        public async Task<ICollection<T>> GetAllItems()
        {
            var items = new List<T>();
            var requestUri = new Uri(BaseApiUri + _subPathUri);
            try
            {
                var response = await _client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<T>>(content);
                }
            }
            catch(Exception ex)
            {
                //ToDo Обработка исключения
                
            }
            return items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OCineManagerApps.OcineManager.DATA
{
   public abstract  class BaseRequest<T> where T: class, new()
   {
       /// <summary>
       /// HttpClient 
       /// </summary>
       private readonly HttpClient _client;

        /// <summary>
        /// Адресс контролера для 
        /// </summary>
        private string _controllerName { get; set; }

        /// <summary>
        /// Контрусктор для generic класс BaseRequest, для выпольнения запроса
        /// </summary>
        protected BaseRequest(string request="")
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://ocinewebapi2.azurewebsites.net/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _controllerName = request;
        }

        /// <summary>
        /// Получить все Элемент типа T
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<T>> GetAllItems()
        {
            
            var items = new List<T>();
            try
            {
                var response = await _client.GetAsync(_controllerName);
                if (response.IsSuccessStatusCode)
                {
                    items = (List<T>) await response.Content.ReadAsAsync<IEnumerable<T>>();
                }
                
            }
            catch (Exception)
            {
                // Todo Обработка исключения на IsSuccessStatusCode==False
            }
            return items;
        }

        /// <summary>
        /// Создать элемент типа Т 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
       public async Task<T> CreateItem(T item)
       {
           try
           {
               var response = await _client.PostAsJsonAsync(_controllerName, item);
               response.EnsureSuccessStatusCode();
               return item;
           }
           catch (Exception ex)
           {

               throw new Exception(ex.Message);
           }
           
       }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Web.Http;

namespace HttpMobileAccesServices
{
    public class WorkWithWebApi<T> where T:class, new()
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private HttpClient _client;

        /// <summary>
        /// Controller that's we need
        /// </summary>
        private string _controller { get; set; }

        /// <summary>
        /// Base Address of our Api
        /// </summary>
        private const string BaseAddress = "http://ocinewebapi.azurewebsites.net/api/";

        /// <summary>
        /// Contructeur
        /// </summary>
        /// <param name="controller">Controller for initialisation</param>
        protected WorkWithWebApi(string controller)
        {
            _client = new HttpClient();
            _controller = controller;
        }

        protected async Task<ICollection<T>> GetAll(string Uri)
        {
            var listResult = new List<T>();
            var uri = new Uri(BaseAddress + _controller); 
            try
            {
                var response = await _client.GetAsync(uri);
            }
        }
    }
}

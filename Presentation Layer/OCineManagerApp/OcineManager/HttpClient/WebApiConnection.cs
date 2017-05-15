using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OCineManagerApps.OcineManager.HttpClient.Interface;

namespace OCineManagerApps.OcineManager.HttpClient
{
    public class WebApiConnection:IWebApiConnection
    {
        public System.Net.Http.HttpClient Client { get; }

        public WebApiConnection()
        {
            Client = new System.Net.Http.HttpClient();
            RunAsync();
        }
        private  void  RunAsync()
        {
            Client.BaseAddress =  new Uri("http://ocinewebapi.azurewebsites.net/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

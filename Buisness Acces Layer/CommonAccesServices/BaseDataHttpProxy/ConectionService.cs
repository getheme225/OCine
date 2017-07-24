//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;

//namespace CommonAccesServices.BaseDataHttpProxy
//{
//    public class ConectionService
//    {

//        protected virtual string Uri { get; }
//        private readonly HttpClient _client;

//        public ConectionService()
//        {
//            Uri = "";
//            _client = new HttpClient();
//            Connect();
//        }

       
//        private void Connect()
//        {

//            _client.BaseAddress = new Uri("http://ocinewebapi.azurewebsites.net/");
//            _client.DefaultRequestHeaders.Accept.Clear();
//            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//        }

      
//        public async Task<T> Create<T>(T obj) where T : class, new()
//        {
//            var t = new T();
//            var reponse = await _client.PostAsJsonAsync(Uri, obj);
//            reponse.EnsureSuccessStatusCode();
//            if (reponse.IsSuccessStatusCode)
//            {
//                t = await reponse.Content.ReadAsAsync<T>();
//            }
//            return t;
//        }

//        public async Task<T> Update<T>(T t) where T : class
//        {
            
//            var reponse = await _client.PutAsJsonAsync(Uri, t);
//            if (!reponse.StatusCode.Equals(HttpStatusCode.NotFound))
//            {
//                t = await reponse.Content.ReadAsAsync<T>();
//            }
//            return t;
//        }

//        public async Task<ICollection<T>> All<T>() where T : class
//        {
//            ICollection<T> list = new List<T>();
//            var reponse = await _client.GetAsync(Uri);
//            if (reponse.IsSuccessStatusCode)
//            {
//                list = await reponse.Content.ReadAsAsync<ICollection<T>>();
//            }
//            return list;
//        }
       
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OCine.BAL.DTO;
using Services.Interfaces;

namespace OcineWebApi.Controllers
{ 
    
    public class CountryController : ApiController
    {
        private readonly ICountryServices _countryServices;

        public CountryController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }
        // GET: api/Default
        public IEnumerable<CountryDto> Get()
        {
            return _countryServices.GetAllCountries();
        }

       
        // POST: api/Default
        public HttpResponseMessage Post(CountryDto country)
        {
            var countryCreated = _countryServices.CreateCountry(country);
            return (country != null)
                ? Request.CreateResponse(HttpStatusCode.Created, countryCreated)
                : Request.CreateErrorResponse(HttpStatusCode.Conflict, "That's Country All ready Exist");
        }

        // PUT: api/Default/5
        public IHttpActionResult Put(CountryDto country)
        {
            var updatedCountry = _countryServices.UpdateCountry(country);
            if (updatedCountry == null) return NotFound();
            return Ok(country);
        }
    }
}

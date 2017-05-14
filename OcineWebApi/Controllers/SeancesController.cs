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
    public class SeancesController : ApiController
    {
        private readonly ISeanceServices _seanceServices;

        public SeancesController(ISeanceServices seanceServices)
        {
            _seanceServices = seanceServices;
        }

        
        // GET: api/Seances
        public IEnumerable<SeancesDto> Get()
        {
            return _seanceServices.GetAllSeance();
        }

        [Route("api/seances/getnewlest")]
        [HttpGet]
        // GET: api/Seances/getnewlest
        public IEnumerable<SeancesDto> GetFeshSeances()
        {
            return _seanceServices.GetAllNewlestSeances();
        }

        [HttpPost]
        // POST: api/Seances
        public HttpResponseMessage Post(SeancesDto seance)
        {
            var canCreate = _seanceServices.CreateSeances(seance);
            return (canCreate)
                ? Request.CreateResponse(HttpStatusCode.ExpectationFailed, seance)
                : Request.CreateErrorResponse(HttpStatusCode.Conflict, $"Seances № {seance.ID_Seances} already exist");
        }

        [HttpPut]
        // PUT: api/Seances/5
        public HttpResponseMessage Put(SeancesDto seance)
        {
            var canUpdate = _seanceServices.UpdateSeance(seance);
            return (canUpdate)
                ? Request.CreateResponse(HttpStatusCode.OK, seance)
                : Request.CreateErrorResponse(HttpStatusCode.Conflict, $"Seances № {seance.ID_Seances} not Exist ");
        }

        [HttpDelete]
        // DELETE: api/Seances/5
        public HttpResponseMessage Delete(SeancesDto seance)
        {
            var canDelete = _seanceServices.DeleteSeances(seance);
            return (canDelete)
                ? Request.CreateResponse(HttpStatusCode.OK, seance)
                : Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Seances № {seance.ID_Seances} doesn't exist ");
        }
    }
}

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
        public IEnumerable<SeanceDto> Get()
        {
            return _seanceServices.GetAllSeance();
        }
        [HttpPost]
        // POST: api/Seances
        public HttpResponseMessage Post(SeanceDto seance)
        {
            var canCreate = _seanceServices.CreateSeances(seance);

            return Request.CreateResponse(HttpStatusCode.Created, canCreate);

        }
        [Route("api/seances/getnewlest")]
        [HttpGet]
        // GET: api/Seances/getnewlest
        public IEnumerable<SeanceDto> GetFeshSeances()
        {
            return _seanceServices.GetAllNewlestSeances();
        }

       

        [HttpPut]
        // PUT: api/Seances/5
        public HttpResponseMessage Put(SeanceDto seance)
        {
            var canUpdate = _seanceServices.UpdateSeance(seance);
            return (canUpdate)
                ? Request.CreateResponse(HttpStatusCode.OK, seance)
                : Request.CreateErrorResponse(HttpStatusCode.Conflict, $"Seances № {seance.ID_Seances} not Exist ");
        }

        [HttpDelete]
        // DELETE: api/Seances/5
        public HttpResponseMessage Delete(SeanceDto seance)
        {
            var canDelete = _seanceServices.DeleteSeances(seance);
            return (canDelete)
                ? Request.CreateResponse(HttpStatusCode.OK, seance)
                : Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Seances № {seance.ID_Seances} doesn't exist ");
        }
    }
}

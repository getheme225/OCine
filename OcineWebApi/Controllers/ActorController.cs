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
    public class ActorController : ApiController
    {
        private readonly IActorsServices _actorsServices;

        public ActorController(IActorsServices actorsServices)
        {
            _actorsServices = actorsServices;
        }
        // GET: api/Actor
        public IEnumerable<ActorDto> Get()
        {
            return _actorsServices.GetAllActor();
        }

   
        // POST: api/Actor
        public HttpResponseMessage Post(ActorDto actor)
        {
            var createdActor = _actorsServices.CreateActors(actor);
            return Request.CreateResponse(HttpStatusCode.Created, createdActor);

        }

        // PUT: api/Actor/5
        public IHttpActionResult Put(ActorDto actor)
        {
            var updatedActor = _actorsServices.UpdateActor(actor);
            if (updatedActor == null) return NotFound();
           return Ok(updatedActor);
        }

        // DELETE: api/Actor/5
        public void Delete(int id)
        {
        }
    }
}

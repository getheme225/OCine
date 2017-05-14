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
   
    public class CinemaController : ApiController
    {
        private readonly ICinemaServices _cinemaService;
        public CinemaController(ICinemaServices cinemaService)
        {
            _cinemaService = cinemaService;
        }
        public IEnumerable<CinemaDto> Get()
        {
            return _cinemaService.GetAllCinema();
        }

        [HttpPost]        
        public HttpResponseMessage Post(CinemaDto cinema)
        {
            var canCreate = _cinemaService.CreateCinema(cinema);
            return (canCreate)
                ? Request.CreateResponse(HttpStatusCode.Created, cinema)
                : Request.CreateErrorResponse(HttpStatusCode.Conflict, "Cinema already exist");
        }

        

        [HttpPut]
        public HttpResponseMessage Put(CinemaDto cinema)
        {
            var canUpdate = _cinemaService.UpdateCinema(cinema);
            return (canUpdate)
                ? Request.CreateResponse(HttpStatusCode.OK, cinema)
                : Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cinema doesn't exist");
        }

        [HttpDelete]
        public HttpResponseMessage Delete(CinemaDto cinema)
        {
            var canDelete = _cinemaService.DeleteCinema(cinema);
            return (canDelete)
                ? Request.CreateResponse(HttpStatusCode.OK, cinema)
                : Request.CreateErrorResponse(HttpStatusCode.Found, "Cinema that's you want to delete doesn't exist");
        }
    }
}

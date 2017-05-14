using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OCine.BAL.DTO;
using Services.Interfaces;


namespace OcineWebApi.Controllers
{
   [RoutePrefix("Film")]
    public class FilmController : ApiController
    {
        private readonly IFilmServices _filmServices;
        
        public FilmController( IFilmServices filmServices)
        {
            _filmServices = filmServices;         
        }
        // GET: api/Film
        
        public IEnumerable<FilmsDto> Get()
        {
          return  _filmServices.GetAllFilm();
        }
        [HttpGet]
        [Route("api/film/GetActualFilms")]
        public IEnumerable<FilmsDto> GetFilms()
        {
            return _filmServices.GetAllActualFilms();           
        }

        [HttpPost]
        public HttpResponseMessage Post(FilmsDto film)
        {
            var canCreate = _filmServices.CreateFilms(film);
            return (canCreate)
                ? Request.CreateResponse(HttpStatusCode.Created, film)
                : Request.CreateErrorResponse(HttpStatusCode.Conflict, "Film already exist");
        }

        [HttpPut]
        public IHttpActionResult Put(FilmsDto film)
        {
            var canUpdate = _filmServices.UpdateFilm(film);
            if (!canUpdate)
            {
                return NotFound();
            }
            else return Ok(film);
        }

        [HttpDelete]
        public IHttpActionResult Delete(FilmsDto film)
        {
            var canDelete = _filmServices.DeleteFilm(film);
            if (!canDelete)
            {
                return NotFound();
            }
            else
            {
                return Ok(film);
            }
        }
    }
}

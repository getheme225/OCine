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
    public class GenreController : ApiController
    {
        private readonly IGenreServices _genreServices;

        public GenreController(IGenreServices genreServices)
        {
            _genreServices = genreServices;
        }
        // GET: api/Genre
        public IEnumerable<GenreDto> Get()
        {
            return _genreServices.GetAllGenres();
        }

        

        // POST: api/Genre
        public HttpResponseMessage Post(GenreDto genre)
        {
            var createdGenre = _genreServices.CreateGenre(genre);
            return Request.CreateResponse(HttpStatusCode.Created, createdGenre);
        }

        // PUT: api/Genre/5
        public IHttpActionResult Put(GenreDto genre)
        {
            var updatedGenre = _genreServices.UpdateGenre(genre);
            if (updatedGenre == null) return NotFound();
            return Ok(genre);
        }

        // DELETE: api/Genre/5
        public void Delete(int id)
        {
        }
    }
}

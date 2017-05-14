using System.Collections.Generic;
using OCine.BAL.DTO;

namespace Services.Interfaces
{
   public interface IFilmServices
   {
       bool CreateFilms(FilmsDto film);
       IEnumerable<FilmsDto> GetAllFilm();
       IEnumerable<FilmsDto> GetAllActualFilms();
       bool UpdateFilm(FilmsDto film);
       bool DeleteFilm(FilmsDto film);
   }
}

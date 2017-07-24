using System.Collections.Generic;
using OCine.BAL.DTO;

namespace Services.Interfaces
{
    public interface IGenreServices
    {
        IEnumerable<GenreDto> GetAllGenres();
        GenreDto CreateGenre(GenreDto genre);
        GenreDto UpdateGenre(GenreDto genre);
    }
}
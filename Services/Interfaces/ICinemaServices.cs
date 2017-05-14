using System.Collections.Generic;
using OCine.BAL.DTO;

namespace Services.Interfaces
{
    public interface ICinemaServices
    {
        bool CreateCinema(CinemaDto cinema);
        bool UpdateCinema(CinemaDto cinema);
        bool DeleteCinema(CinemaDto cinema);
        IEnumerable<CinemaDto> GetAllCinema();
    }
}
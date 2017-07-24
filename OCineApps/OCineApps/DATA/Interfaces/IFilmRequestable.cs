using OCine.BAL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OCineApps.DATA.Interfaces
{
    /// <summary>
    /// получить список всех фильмов
    /// </summary>
    public interface IFilmRequestable
    {
         Task<ICollection<FilmsDto>> GetAllItems();
    }
}
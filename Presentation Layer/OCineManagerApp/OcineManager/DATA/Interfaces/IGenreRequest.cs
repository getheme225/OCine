using System.Collections.Generic;
using System.Threading.Tasks;
using OCine.BAL.DTO;

namespace OCineManagerApps.OcineManager.DATA.Interfaces
{
    public interface IGenreRequest
    {
        Task<ICollection<GenreDto>> GetAllItems();
        Task<GenreDto> CreateItem(GenreDto item);
    }
}
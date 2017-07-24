using OCine.BAL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OCineManagerApps.OcineManager.DATA.Interfaces
{
    public interface ICinemaRequest
    {
        Task<ICollection<CinemaDto>> GetAllItems();
        Task<CinemaDto> CreateItem(CinemaDto item);
    }
}
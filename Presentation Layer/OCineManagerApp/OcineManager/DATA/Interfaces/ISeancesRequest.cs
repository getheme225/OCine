using System.Collections.Generic;
using System.Threading.Tasks;
using OCine.BAL.DTO;

namespace OCineManagerApps.OcineManager.DATA.Interfaces
{
    public interface ISeancesRequest
    {
        Task<ICollection<SeanceDto>> GetAllItems();
        Task<SeanceDto> CreateItem(SeanceDto item);
    }
}
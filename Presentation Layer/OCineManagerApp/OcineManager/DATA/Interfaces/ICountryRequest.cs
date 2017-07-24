using System.Collections.Generic;
using System.Threading.Tasks;
using OCine.BAL.DTO;

namespace OCineManagerApps.OcineManager.DATA.Interfaces
{
    public interface ICountryRequest
    {
        Task<ICollection<CountryDto>> GetAllItems();
        Task<CountryDto> CreateItem(CountryDto item);
    }
}
using System.Collections.Generic;
using OCine.BAL.DTO;

namespace Services.Interfaces
{
    public interface ICountryServices
    {
        IEnumerable<CountryDto> GetAllCountries();
        CountryDto CreateCountry(CountryDto country);
        CountryDto UpdateCountry(CountryDto country);
    }
}
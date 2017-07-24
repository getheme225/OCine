using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.DATA.Interfaces;

namespace OCineManagerApps.OcineManager.DATA
{
    /// <summary>
    /// Класс запрос для Стран
    /// </summary>
    public class CountryRequest : BaseRequest<CountryDto>, ICountryRequest
    {
        /// <summary>
        /// uri= http://ocinewebapi.azurewebsites.net/api/Country
        /// </summary>
       public CountryRequest() : base("Country")
        {

        }
    }
}

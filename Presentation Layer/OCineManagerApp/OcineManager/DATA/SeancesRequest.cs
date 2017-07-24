using OCine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCineManagerApps.OcineManager.DATA.Interfaces;

namespace OCineManagerApps.OcineManager.DATA
{
    /// <summary>
    /// Класс запрос для Сеансов для Manager App
    /// </summary>
    public class SeancesRequest: BaseRequest<SeanceDto>, ISeancesRequest
    {
        public SeancesRequest() : base("Seances")
        {
            
        }
    }
}

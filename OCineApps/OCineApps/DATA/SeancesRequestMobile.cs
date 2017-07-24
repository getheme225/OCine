using OCine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCineApps.DATA.Interfaces;

namespace OCineApps.DATA
{
   public class SeancesRequestMobile:BaseRestApi<SeanceDto>, ISeancesRequestable
    {
        /// <summary>
        /// Конструктор класса для получения всех сеансов
        /// </summary>
        /// <param name="controller"> http://ocinewebapi.azurewebsites.net/api/Seances </param>
        public SeancesRequestMobile(string controller = "Seances") : base(controller)
        {

        }
    }
}

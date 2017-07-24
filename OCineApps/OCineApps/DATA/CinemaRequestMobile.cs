using OCine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCineApps.DATA.Interfaces;

namespace OCineApps.DATA
{
   public class CinemaRequestMobile:BaseRestApi<CinemaDto>, ICinemaRequestable
    {
        /// <summary>
        /// Конструктор класса запрос на получении список всех кинотеатров
        /// </summary>
        /// <param name="controller"> http://ocinewebapi.azurewebsites.net/api/Cinema  </param>
        public CinemaRequestMobile(string controller = "Cinema") : base(controller)
        {

        }
    }
}

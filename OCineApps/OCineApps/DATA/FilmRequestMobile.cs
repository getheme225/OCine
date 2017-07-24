using OCine.BAL.DTO;
using OCineApps.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCineApps.DATA.Interfaces;

namespace OCineApps.DATA
{
    public class FilmRequestMobile: DATA.BaseRestApi<FilmsDto>, IFilmRequestable
    {
        /// <summary>
        /// Конструтор класс запроса Get 
        /// </summary>
        /// <param name="controller"> http://ocinewebapi.azurewebsites.net/api/Film </param>
        public FilmRequestMobile(string controller= "Film") : base(controller)
        {
                
        }
    }
}

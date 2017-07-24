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
    /// Класс запрос для Фильмов
    /// </summary>
    public class FilmsRequest : BaseRequest<FilmsDto>, IFilmsRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public FilmsRequest() : base("Film")
        {
        }
    }
}

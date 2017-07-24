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
    /// Класс запрос для Жанров
    /// </summary>
    public class GenreRequest : BaseRequest<GenreDto>, IGenreRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public GenreRequest() : base("Genre")
        {
        }
    }
}

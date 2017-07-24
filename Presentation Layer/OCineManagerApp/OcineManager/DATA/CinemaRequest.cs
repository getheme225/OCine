using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.DATA.Interfaces;

namespace OCineManagerApps.OcineManager.DATA
{
    /// <summary>
    /// Класс запрос для кинотеатров
    /// </summary>
   public class CinemaRequest: BaseRequest<CinemaDto>, ICinemaRequest
    {
        /// <summary>
        /// 
        /// </summary>
       public CinemaRequest() : base("Cinema")
        {
            
        }
    }
}

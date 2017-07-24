using OCine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCineApps.DATA.Interfaces
{
    /// <summary>
    /// Получить список всех кинотеатров
    /// </summary>
   public interface ICinemaRequestable
   {
       Task<ICollection<CinemaDto>> GetAllItems();
   }
}

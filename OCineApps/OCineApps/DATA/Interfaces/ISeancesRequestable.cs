using OCine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCineApps.DATA.Interfaces
{
    /// <summary>
    /// Интерфейс для получения всех сеансов
    /// </summary>
    interface ISeancesRequestable
    {
        Task<ICollection<SeanceDto>> GetAllItems();
    }
}

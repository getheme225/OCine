using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCine.BAL.DTO;

namespace OCineManagerApps.OcineManager.DATA.Interfaces
{
  public interface IFilmsRequest
    {
        Task<ICollection<FilmsDto>> GetAllItems();
        Task<FilmsDto> CreateItem(FilmsDto item);
    }
}

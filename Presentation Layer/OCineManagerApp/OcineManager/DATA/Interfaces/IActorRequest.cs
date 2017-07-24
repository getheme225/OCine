using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCine.BAL.DTO;

namespace OCineManagerApps.OcineManager.DATA.Interfaces
{
    public interface IActorRequest
    {
        Task<ICollection<ActorDto>> GetAllItems();
        Task<ActorDto> CreateItem(ActorDto item);
    }
}

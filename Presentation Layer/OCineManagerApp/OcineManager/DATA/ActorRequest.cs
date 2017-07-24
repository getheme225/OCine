using OCine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCineManagerApps.OcineManager.DATA.Interfaces;

namespace OCineManagerApps.OcineManager.DATA
{
    /// <summary>
    /// Класс запрос для Актёров
    /// </summary>
    public class ActorRequest : BaseRequest<ActorDto>, IActorRequest
    {
        public ActorRequest():base("Actor")
        {
            
        }
    }
}

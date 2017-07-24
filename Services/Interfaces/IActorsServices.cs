using System.Collections.Generic;
using OCine.BAL.DTO;

namespace Services.Interfaces
{
    public interface IActorsServices
    {
        IEnumerable<ActorDto> GetAllActor();
        ActorDto CreateActors(ActorDto actor);
        ActorDto UpdateActor(ActorDto actor);

    }
}
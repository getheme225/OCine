using System.Collections.Generic;
using OCine.BAL.DTO;

namespace Services.Interfaces
{
    public interface IPremiereServices
    {
        IEnumerable<PremiereDto> GetAllPremiere();
        PremiereDto CreatePremiere(PremiereDto premiere, FilmsDto film);
    }
}
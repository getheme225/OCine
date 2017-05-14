using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCine.BAL.DTO;

namespace Services.Interfaces
{
  public interface ISeanceServices
  {
      bool CreateSeances(SeancesDto seance);
      IEnumerable<SeancesDto> GetAllSeance();
      IEnumerable<SeancesDto> GetAllNewlestSeances();
      bool UpdateSeance(SeancesDto seance);
      bool DeleteSeances(SeancesDto seance);


  }
}

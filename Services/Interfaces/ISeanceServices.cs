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
      SeanceDto CreateSeances(SeanceDto seance);
      IEnumerable<SeanceDto> GetAllSeance();
      IEnumerable<SeanceDto> GetAllNewlestSeances();
      bool UpdateSeance(SeanceDto seance);
      bool DeleteSeances(SeanceDto seance);


  }
}

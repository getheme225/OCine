using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCine.BAL.DTO;
using PropertyChanged;

namespace OCineManagerApps.OcineManager.Helper
{
    [ImplementPropertyChanged]
    public class FilmSchedule
    {
        public string FilmTitle { get; set; }
        public List<TimeSpan?> SeancesTime { get; set; }
    }
}

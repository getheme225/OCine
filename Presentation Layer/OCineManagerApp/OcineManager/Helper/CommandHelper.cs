using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCineManagerApps.OcineManager.RefreshInterface;

namespace OCineManagerApps.OcineManager.Helper
{
    public class CommandHelper
    {
        public IClosable ClosePage { get; }
        public IFilmRefreshable RefreashFilmList { get; }
    }
}

using System;
using System.Collections.Generic;

namespace OCine.BAL.Entity
{
    public partial class Country
    {
      
        public Country()
        {
            this.Films = new HashSet<Films>();
        }

        public int ID_Country { get; set; }
        public string Country1 { get; set; }

      
        public virtual ICollection<Films> Films { get; set; }
    }
}

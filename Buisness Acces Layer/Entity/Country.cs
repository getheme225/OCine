using System;
using System.Collections.Generic;

namespace OCine.BAL.Entity
{
    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            this.Films = new HashSet<Films>();
        }

        public int ID_Country { get; set; }
        public string Country1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Films> Films { get; set; }
    }
}

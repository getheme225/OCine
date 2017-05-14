using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;

namespace OCine.BAL.Entity
{
    public partial class Cinema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cinema()
        {
            this.Seances = new HashSet<Seances>();
        }

        public int ID_Cinema { get; set; }
        public string CinemaName { get; set; }
        public string Telephone { get; set; }
        public DbGeography Address { get; set; }
        public string WebSite { get; set; }
        public double? Raiting { get; set; }
        public byte[] Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seances> Seances { get; set; }
    }
}

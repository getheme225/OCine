using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OCine.BAL.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Films
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Films()
        {
            this.Seances = new HashSet<Seances>();
            this.Premiere = new HashSet<Premiere>();
            this.Actor = new HashSet<Actor>();
            this.Country = new HashSet<Country>();
            this.Genres = new HashSet<Genres>();
            this.User = new HashSet<User>();
        }

        public int ID_film { get; set; }
        public string Title { get; set; }
        public Nullable<int> AgePG { get; set; }
        public string DirectorProduction { get; set; }
        public Nullable<System.TimeSpan> Duration { get; set; }
        public string TraillerUrl { get; set; }
        public byte[] Affiche { get; set; }
        public Nullable<double> Rating { get; set; }
        public string About { get; set; }
        public Nullable<bool> HasInScreening { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seances> Seances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Premiere> Premiere { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actor> Actor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Country> Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Genres> Genres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }

}

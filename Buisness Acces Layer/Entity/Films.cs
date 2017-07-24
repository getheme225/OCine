using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OCine.BAL.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Films
    {
     
        public Films()
        {
            this.Seance = new HashSet<Seance>();
            this.Premiere = new HashSet<Premiere>();
            this.Actor = new HashSet<Actor>();
            this.Country = new HashSet<Country>();
            this.Genre = new HashSet<Genre>();
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

       
        public virtual ICollection<Seance> Seance { get; set; }
       
        public virtual ICollection<Premiere> Premiere { get; set; }
     
        public virtual ICollection<Actor> Actor { get; set; }
      
        public virtual ICollection<Country> Country { get; set; }
     
        public virtual ICollection<Genre> Genre { get; set; }
        
        public virtual ICollection<User> User { get; set; }
    }

}

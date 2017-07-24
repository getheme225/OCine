using System.Collections.Generic;

namespace OCine.BAL.Entity
{
    public partial class Genre
    {
     
        public Genre()
        {
            this.Films = new HashSet<Films>();
            
        }

        public int ID_Genre { get; set; }
        public string GenreName { get; set; }

       
        public virtual ICollection<Films> Films { get; set; }
    }
}

using System.Collections.Generic;

namespace OCine.BAL.Entity
{
    public partial class Actor
    {
     
        public Actor()
        {
            this.Films = new HashSet<Films>();
        }

        public int ID_Actor { get; set; }
        public string Name { get; set; }

       
        public virtual ICollection<Films> Films { get; set; }
    }
}

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
        
        public Cinema()
        {
            this.Seance = new HashSet<Seance>();
        }

        public int ID_Cinema { get; set; }
        public string CinemaName { get; set; }
        public string Telephone { get; set; }
        public double? Address_Longitude { get; set; }
        public double? Address_Latitude { get; set; }
        public string WebSite { get; set; }
        public double? Raiting { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Seance> Seance { get; set; }
    }
}

using System;

namespace OCine.BAL.Entity
{
    public partial class Seances
    {
        public int ID_Seances { get; set; }
        public DateTime? PlayingDate { get; set; }
        public TimeSpan? PlayingTime { get; set; }
        public int? ID_Cinema { get; set; }
        public string UrlSeances { get; set; }
        public int? ID_Film { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Films Films { get; set; }
    }
}

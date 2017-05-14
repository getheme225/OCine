using System;

namespace OCine.BAL.Entity
{
    public partial class Premiere
    {
        public int ID_Premiere { get; set; }
        public DateTime? PremiereDate { get; set; }
        public string CountryPremieres { get; set; }
        public int? ID_film { get; set; }

        public virtual Films Films { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace OCine.BAL.DTO
{
    public partial class PremiereDto
    {
        public int ID_Premiere { get; set; }
        public DateTime? PremiereDate { get; set; }
        public string CountryPremieres { get; set; }
        public int? ID_film { get; set; }
       
    }
}

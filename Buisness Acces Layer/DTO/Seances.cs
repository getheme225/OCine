using System;

namespace OCine.BAL.DTO
{
    public partial class SeancesDto
    {
        public int ID_Seances { get; set; }
        public DateTime? PlayingDate { get; set; }
        public TimeSpan? PlayingTime { get; set; }
        public CinemaDto Cinema { get; set; }
        public string UrlSeances { get; set; }
        public FilmsDto Film{ get; set; }
    }
}

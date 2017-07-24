using System;

namespace OCine.BAL.DTO
{
    public partial class SeanceDto
    {
        public int ID_Seances { get; set; }
        public DateTime? PlayingDate { get; set; }
        public TimeSpan? PlayingTime { get; set; }
        public CinemaDto Cinema { get; set; }
        public string UrlSeances { get; set; }
        public FilmsDto Films{ get; set; }
        public bool? Has3D { get; set; }
    }
}

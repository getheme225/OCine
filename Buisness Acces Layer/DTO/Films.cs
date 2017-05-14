using System;
using System.Collections.Generic;
using System.Linq;

namespace OCine.BAL.DTO
{
    public partial class FilmsDto
    {
        public int ID_film { get; set; }
        public string Title { get; set; }
        public int? AgePG { get; set; }
        public string DirectorProduction { get; set; }
        public TimeSpan? Duration { get; set; }
        public string TraillerUrl { get; set; }
        public byte[] Affiche { get; set; }
        public double? Rating { get; set; }
        public string About { get; set; }
        public bool? HasInScreening { get; set; }
        public ICollection<ActorDto> Actors { get; set; }
        public ICollection<CountryDto> Countries { get; set; }
        public ICollection<PremiereDto> Premieres { get; set;}
        public ICollection<GenresDto> Genres { get; set; }
    }
}

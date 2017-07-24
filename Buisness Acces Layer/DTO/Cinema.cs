

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.SqlServer.Types;

namespace OCine.BAL.DTO
{
    public partial class CinemaDto
    {

        public int ID_Cinema { get; set; }
        public string CinemaName { get; set; }
        public string Telephone { get; set; }
        public double? Address_Longitude { get; set; }
        public double? Address_Latitude { get; set; }
        public string WebSite { get; set; }
        public double? Raiting { get; set; }
        public byte[] Image { get; set; }
        public ICollection<SeanceDto> Seance { get; set; }

        public CinemaDto()
        {
            Seance = new HashSet<SeanceDto>();
        }
    }
}

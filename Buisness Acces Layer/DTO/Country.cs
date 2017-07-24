using System.Collections.Generic;

namespace OCine.BAL.DTO
{
    public partial class CountryDto
    {
        public int ID_Country { get; set; }
        public string Country1 { get; set; }
        public List<FilmsDto> FilmsDto { get; set; }

    }
}

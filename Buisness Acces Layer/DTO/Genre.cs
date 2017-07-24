using System.Collections.Generic;

namespace OCine.BAL.DTO
{
    public partial class GenreDto
    {
        public int ID_Genre { get; set; }
        public string GenreName { get; set; }
        public ICollection<FilmsDto> FilmsDto { get; set; }
        
    }
}

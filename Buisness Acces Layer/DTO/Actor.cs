using System.Collections.Generic;
using OCine.BAL.DTO;

namespace OCine.BAL.DTO
{
    public partial class ActorDto
    {
        public int ID_Actor { get; set; }
        public string Name { get; set; }
        public ICollection<FilmsDto> FilmsDto { get; set; }

       
       
    }
}

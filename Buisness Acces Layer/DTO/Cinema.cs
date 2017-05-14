

using System.Data.Entity.Spatial;

namespace OCine.BAL.DTO
{
    public partial class CinemaDto
    {

        public int ID_Cinema { get; set; }
        public string CinemaName { get; set; }
        public string Telephone { get; set; }
        public DbGeography Address { get; set; }
        public string WebSite { get; set; }
        public double? Raiting { get; set; }
        public byte[] Image { get; set; }
        
    }
}

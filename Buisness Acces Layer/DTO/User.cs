using System;

namespace OCine.BAL.DTO
{
    public partial class UserDto
    {
        public int ID_client { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}

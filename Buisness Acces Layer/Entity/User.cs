using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OCine.BAL.Entity
{
    public partial class User
    {
        
        public User()
        {
            this.Films = new HashSet<Films>();
        }

        public int ID_client { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public DateTime? BirthDay { get; set; }

       
        public virtual ICollection<Films> Films { get; set; }
    }
}

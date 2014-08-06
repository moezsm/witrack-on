using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Sdz_user
    {
        public int Sdz_userID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password_user { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

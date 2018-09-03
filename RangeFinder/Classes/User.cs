using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeFinder.Classes
{
    class User
    {
        

        public User(string userName, int phoneNumber, bool listed)
        {
            this.UserName = userName;
            this.PhoneNumber = phoneNumber;
            this.Listed = listed;
        }

        public bool Listed { get; set; }

        public string UserName { get; set; }

        public int PhoneNumber { get; set; }
    }
}

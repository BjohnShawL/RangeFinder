using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeFinder.Classes
{
    public class User
    {
        

        public User(string userName, long phoneNumber, bool listed)
        {
            this.UserName = userName;
            this.PhoneNumber = phoneNumber;
            this.Listed = listed;
        }

        public bool Listed { get; set; }

        public string UserName { get; set; }

        public long PhoneNumber { get; set; }
    }
}

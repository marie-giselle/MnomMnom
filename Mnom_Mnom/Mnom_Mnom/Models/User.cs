using System;
using System.Collections.Generic;

namespace Mnom_Mnom.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int TelNumbet { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}

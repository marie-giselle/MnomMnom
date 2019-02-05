using System;
using System.Collections.Generic;

namespace Mnom_Mnom.Models
{
    public class UserAddress
    {
        public int UserID { get; set; }
        public int AddressID { get; set; }

        public User User { get; set; }
        public Address Address { get; set; }
    }
}

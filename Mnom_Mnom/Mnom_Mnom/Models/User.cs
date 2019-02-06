using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mnom_Mnom.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [XmlElement(DataType = "date")]
        public DateTime RegistrationDate { get; set; }
        public string TelNumber { get; set; }        
        
        public List<Address> Addresses { get; set; }
    }
}

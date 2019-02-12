using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Mnom_Mnom.Models
{
	public enum Role
	{
		User,
		Admin
	}

    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        [XmlElement(DataType = "date")]
        public DateTime RegistrationDate { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string TelNumber { get; set; } 

		public Role Role { get; set; }
        
        public List<Address> Addresses { get; set; }
    }
}

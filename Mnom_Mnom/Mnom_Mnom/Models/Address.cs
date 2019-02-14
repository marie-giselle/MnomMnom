namespace Mnom_Mnom.Models
{
    [System.Xml.Serialization.XmlRoot("Addresses")]
    public class Address
    {
        public int AddressID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string Region { get; set; }
        public string Comment { get; set; }
    }
}
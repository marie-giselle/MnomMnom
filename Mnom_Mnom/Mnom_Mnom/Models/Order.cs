using System;
using System.Collections.Generic;

namespace Mnom_Mnom.Models
{
    public enum OrderStatus
    {
        New,
        Accepted,
        Assembling,
        Delivering,
        Done,
        Canceled
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int AddressID { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Time { get; set; }
        public int PriceTotal { get; set; }
        public string Comment { get; set; }

        public User User { get; set; }
        public Address Address { get; set; }
    }
}

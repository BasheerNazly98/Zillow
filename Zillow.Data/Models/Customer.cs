using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Data.Models
{
    public class Customer : BaseEntity
    {
        public string name { get; set; }
        public string phone { get; set; }
        public int addressId { get; set; }
        public Address address { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}

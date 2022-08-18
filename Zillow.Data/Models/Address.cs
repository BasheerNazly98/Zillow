using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Data.Models
{
    public class Address : BaseEntity
    {
        public string countryName { get; set; }
        public string cityName { get; set; }
        public List<Customer> customers { get; set; }
        public List<RealEstate> realEstates { get; set; }
    }
}

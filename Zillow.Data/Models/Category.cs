using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Data.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string description { get; set; }
        public List<RealEstate> realEstates { get; set; }
    }
}

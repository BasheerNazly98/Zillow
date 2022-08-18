using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Data.Models
{
    public class RealEstate : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int addressId { get; set; }
        public Address address { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
        public List<Contract> contracts { get; set; }
        public List<Image> images { get; set; }



    }
}

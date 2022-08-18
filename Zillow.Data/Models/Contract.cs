using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Data.Models
{
    public class Contract : BaseEntity
    {
        public string contractType { get; set; }
        public float Price { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }
        public int realEstateId { get; set; }
        public RealEstate realEstate { get; set; }
    }
}

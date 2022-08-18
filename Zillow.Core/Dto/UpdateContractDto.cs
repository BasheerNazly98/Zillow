using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.Dto
{
    public class UpdateContractDto
    {
        public int id { get; set; }
        public string contractType { get; set; }
        public float Price { get; set; }
        public int customerId { get; set; }
        public int realEstateId { get; set; }
    }
}

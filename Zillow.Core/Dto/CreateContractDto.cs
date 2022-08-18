using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.Dto
{
    public class CreateContractDto
    {

        public string contractType { get; set; }
        public float Price { get; set; }
        public int customerId { get; set; }
        public int realEstateId { get; set; }
    }
}

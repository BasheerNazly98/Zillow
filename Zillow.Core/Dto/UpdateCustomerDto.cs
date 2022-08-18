using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.Dto
{
    public class UpdateCustomerDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int addressId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Zillow.Core.ViewModel;

namespace Zillow.Core.Dto
{
    public class CreateCustomerDto
    {
        public string name { get; set; }
        public string phone { get; set; }
        public int addressId { get; set; }
    }
}

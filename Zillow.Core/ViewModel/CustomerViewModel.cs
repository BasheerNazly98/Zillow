using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public AddressViewModel address { get; set; }

    }
}

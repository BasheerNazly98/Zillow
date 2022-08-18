using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.ViewModel
{
    public class RealEstateViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AddressViewModel address { get; set; }
        public CategoryViewModel category { get; set; }
        public List<ContractViewModel> contracts { get; set; }
        public List<string> images { get; set; }
    }
}

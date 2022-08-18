using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.ViewModel
{
    public class ContractViewModel
    {
        public int id { get; set; }
        public string contractType { get; set; }
        public float Price { get; set; }
        public CustomerViewModel customer { get; set; }
        //public RealEstateViewModel realEstate { get; set; }
    }
}

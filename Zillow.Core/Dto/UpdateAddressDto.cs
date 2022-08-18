using System;
using System.Collections.Generic;
using System.Text;
using Zillow.Core.ViewModel;

namespace Zillow.Core.Dto
{
    public class UpdateAddressDto
    {
        public int Id { get; set; }
        public string countryName { get; set; }
        public string cityName { get; set; }
    }
}

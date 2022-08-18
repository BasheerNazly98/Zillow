using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.Dto
{
    public class UpdateRealEstateDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int addressId { get; set; }
        public int categoryId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Data.Models
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }
        public int realEstateId { get; set; }
        public RealEstate realEstate { get; set; }
    }
}

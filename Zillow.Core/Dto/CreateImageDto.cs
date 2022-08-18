using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.Dto
{
    public class CreateImageDto
    {
        public string Path { get; set; }
        public int realEstateId { get; set; }
    }
}

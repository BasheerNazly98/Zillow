using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.Dto
{
    public class UpdateCategoryDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Zillow.Core.ViewModel;

namespace Zillow.Core.Dto
{
    public class CreateRealEstateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int addressId { get; set; }
        public int categoryId { get; set; }
        public List<IFormFile> images { get; set; }

    }
}

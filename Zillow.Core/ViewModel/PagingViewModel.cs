using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Core.ViewModel
{
    public class PagingViewModel
    {
        public int numOfPages { get; set; }
        public int cureentPage { get; set; }
        public Object data { get; set; }
    }
}

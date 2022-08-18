using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Data.Models
{
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDelete = false;
        }
    }
    }

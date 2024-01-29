using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_EF.Models
{
    public class CategoryDetail
    {
        public int CategoryDetailId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public int CountProduct { get; set; }
        public Category Category { get; set; }
    }
}

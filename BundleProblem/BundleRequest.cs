using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleProblem
{
    public class BundleRequest
    {
        public Product BundldProduct { get; set; }
        public List<Product>? Products { get;  set;  }
    }
}

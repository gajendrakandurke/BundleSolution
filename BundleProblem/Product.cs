using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleProblem
{
    public class Product
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int RequiredNumberOfUnit { get; set; }
        public string? ParentId { get; set; }
        public int AvailbleStock { get; set; }
        public int NumberProductAvailableForBundle { get; set; }
        public List<Product>? ProductParts { get; set; }
    }
}

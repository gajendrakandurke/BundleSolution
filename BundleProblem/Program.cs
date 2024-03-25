using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace BundleProblem
{
    class Program
    { 
        static void Main(string[] args)
        {
            Bundle bundle = new Bundle();
            int result = bundle.getFinalProduct(GetSampleInputValues());
            Console.WriteLine("Maximumn number of finished bundles - {0} ",result);
            Console.ReadLine();
        }

        //This Methos for Sample Input 
        public static BundleRequest GetSampleInputValues()
        {

            var productParts = new List<Product>()
            {
                new Product{
                    ProductId = "S1",
                    ProductName = "Seat",
                    RequiredNumberOfUnit = 1,
                    AvailbleStock =50,
                    ParentId = "B1",
                },
                 new Product{
                    ProductId = "W1",
                    ProductName = "Wheels",
                    RequiredNumberOfUnit = 2,
                    ParentId = "B1",
                    ProductParts = new List<Product>()
                                        {
                                            new Product{
                                                ProductId = "F1",
                                                ProductName = "Frame",
                                                RequiredNumberOfUnit = 1,
                                               // AvailbleStock = 17,
                                                ParentId = "W1",
                                                ProductParts = new List<Product>(){
                                                              new Product
                                                              {
                                                                ProductId = "GK1",
                                                                ProductName = "GK222",
                                                                RequiredNumberOfUnit = 2,
                                                                AvailbleStock = 12,
                                                                ParentId = "F1",
                                                                ProductParts = new List<Product>()
                                                                                {
                                                                                    new Product
                                                                                    {
                                                                                        ProductId = "mk1",
                                                                                        ProductName = "mk222",
                                                                                        RequiredNumberOfUnit = 2,
                                                                                        AvailbleStock = 4,
                                                                                        ParentId = "GK1",
                                                                                    }
                                                                                }
                                                            },
                                                }

                                            },
                                            new Product{
                                                ProductId = "T1",
                                                ProductName = "Tube",
                                                RequiredNumberOfUnit = 1,
                                                AvailbleStock = 60,
                                                ParentId = "W1",
                                            },
                                       }
                    },
                 new Product{
                    ProductId = "P1",
                    ProductName = "Pedals",
                    RequiredNumberOfUnit = 2,
                    AvailbleStock =60,
                    ParentId = "B1",
                }

            };
            var bundleRequest = new BundleRequest
            {
                BundldProduct = new Product
                {
                    ProductId = "B1",
                    ProductName = "Bike",
                },
                Products = productParts

            };

            return bundleRequest;

        }
    }
}

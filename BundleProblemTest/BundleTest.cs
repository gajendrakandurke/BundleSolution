using BundleProblem;

namespace BundleProblemTest
{
    public class BundleTest
    {
        
        [Test]
        public void GetFinalProductTest()
        {
            Bundle bundle = new Bundle();
            int result = bundle.getFinalProduct(GetSampleInputValues());
            Assert.That(result, Is.EqualTo(6));

            result = bundle.getFinalProduct(GetSampleInputValuesFourLevel());
            Assert.That(result, Is.EqualTo(1));
        }

        private BundleRequest GetSampleInputValuesFourLevel()
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
                                                                ProductId = "F12",
                                                                ProductName = "Frame2",
                                                                RequiredNumberOfUnit = 2,
                                                                AvailbleStock = 12,
                                                                ParentId = "F1",
                                                                ProductParts = new List<Product>()
                                                                                {
                                                                                    new Product
                                                                                    {
                                                                                        ProductId = "SF1",
                                                                                        ProductName = "SubFrame",
                                                                                        RequiredNumberOfUnit = 2,
                                                                                        AvailbleStock = 4,
                                                                                        ParentId = "F12",
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


        private BundleRequest GetSampleInputValues()
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
                                                                ProductId = "F12",
                                                                ProductName = "Frame2",
                                                                RequiredNumberOfUnit = 2,
                                                                AvailbleStock = 12,
                                                                ParentId = "F1",
                                                                
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
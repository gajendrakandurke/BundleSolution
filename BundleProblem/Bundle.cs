using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleProblem
{
    public class Bundle
    {
        // Collection to store calculated product values to required build bundle 
        List<Product> lstBundleProduct = null; 

        /// <summary>
        /// This Method to get number of Final Prodcut Bundle can be build based on input
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int getFinalProduct(BundleRequest request)
        {
            lstBundleProduct = new List<Product>();
            foreach (var product in request.Products)
            {
                if (product.ProductParts is null) // IF the product does not have child product
                {
                    product.NumberProductAvailableForBundle = product.AvailbleStock / product.RequiredNumberOfUnit;
                    lstBundleProduct.Add(product);
                }
                else
                {
                    GetBundleProducts(product);
                }
            }

            return lstBundleProduct.Where(t => t.ParentId == request.BundldProduct.ProductId).Min(t => t.NumberProductAvailableForBundle);//bundleParts.MinBy(kvp => kvp.Value).Value;
        }

        /// <summary>
        /// Method to read all the child nodes and calculate required product to build bundle
        /// </summary>
        /// <param name="product"></param>
        /// <param name="index"></param>
        private void GetBundleProducts(Product product, int index = 0)
        {
            if (product.ProductParts is null)
            {

                product.NumberProductAvailableForBundle = product.AvailbleStock / product.RequiredNumberOfUnit;
                lstBundleProduct.Add(product);

                //Below code is updating Parent and it's Grand parent node values based on child Stocks Availability
                var parentProduct = lstBundleProduct.Where(t => t.ProductId == product.ParentId).FirstOrDefault();
                if (parentProduct?.NumberProductAvailableForBundle == 0 || parentProduct?.NumberProductAvailableForBundle > (product.AvailbleStock / product?.RequiredNumberOfUnit))
                {
                    parentProduct.NumberProductAvailableForBundle = product.AvailbleStock / product.RequiredNumberOfUnit;
                    parentProduct.AvailbleStock = product.AvailbleStock / product.RequiredNumberOfUnit;

                    var grandparentProduct = lstBundleProduct.Where(t => t.ProductId == parentProduct.ParentId).FirstOrDefault();

                    if (grandparentProduct?.NumberProductAvailableForBundle == 0 || grandparentProduct?.NumberProductAvailableForBundle > (grandparentProduct?.AvailbleStock / grandparentProduct?.RequiredNumberOfUnit))
                    {
                        grandparentProduct.NumberProductAvailableForBundle = parentProduct.AvailbleStock / parentProduct.RequiredNumberOfUnit;
                        grandparentProduct.AvailbleStock = parentProduct.AvailbleStock / parentProduct.RequiredNumberOfUnit;
                    }
                }

            }

            else
            {
                product.NumberProductAvailableForBundle = 0;
                lstBundleProduct.Add(product);

                while (product.ProductParts.Count > index)
                {
                    GetBundleProducts(product.ProductParts[index], index++);
                }
            }

            //Below code is for update Top Parent node values based on child Stocks Availability.
            var productAvailableForBundle = lstBundleProduct.Where(t => t.NumberProductAvailableForBundle == 0).FirstOrDefault();
            if (productAvailableForBundle != null)
            {
                productAvailableForBundle.NumberProductAvailableForBundle = lstBundleProduct.Where(t => t.ParentId == productAvailableForBundle.ProductId).Min(t => t.NumberProductAvailableForBundle);
            }

        } 
    }
}

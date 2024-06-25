using System.Xml.Linq;
using System;

namespace wish_well_1.Controllers
{
    public class ProductsCsvController
    {
        public bool checkIfProductExists(int productId)
        {
            var productExists = false;
            CsvController.ReadEachProductByLambda((Product Product) => {
                if (Product.ID == productId)
                {
                    productExists = true;
                }
                else 
                {
                    productExists = false;
                }
            });
            return productExists;
        }
        public bool addProductToList(int productId, string Url, string Name, string Price, int userID ) {
            if (!checkIfProductExists(productId))
            {
                return CsvController.AddProduct(Url, Name, Price, userID);
            }
            else
            {
                return true;
            }
        }
        public Product[] getProductsByUserId(int userId) { 
            var products = new List<Product>();
            CsvController.ReadEachProductByLambda((Product product) => {
                if (product.UserId == userId) {
                    products.Add(product);
                }
            });
            return products.ToArray();
        }
    }
}

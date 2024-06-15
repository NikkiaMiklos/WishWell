using System.Diagnostics;

namespace wish_well_1.Controllers
{
    public static class ExampleCsvControllerUse
    {
        public static void TestUser()
        {
            Debug.WriteLine("*********** Start Read ************");
            CsvController.ReadEachUserByLambda((User user) => {
                Debug.WriteLine(user.AsCsvSafeString());
            });

            Debug.WriteLine("*********** Start Add ************");

            CsvController.AddUser( "test,", "test", "pass");

            
            

            CsvController.ReadEachUserByLambda((User user) => {
                Debug.WriteLine(user.AsCsvSafeString());
            });

            Debug.WriteLine("*********** Start Delete ************");
            
            CsvController.DeleteUsersByLambda((User user) => {
                return user.ID == 1;
            });

            CsvController.ReadEachUserByLambda((User user) => {
                Debug.WriteLine(user.AsCsvSafeString());
            });


            Debug.WriteLine("*********** Done ************");
        }
        public static void TestProduct() {
            Debug.WriteLine("*********** Start Read ************");
            CsvController.ReadEachProductByLambda((Product Product) => {
                Debug.WriteLine(Product.AsCsvSafeString());
            });

            Debug.WriteLine("*********** Start Add ************");

            CsvController.AddProduct("test,", "test", "pass",2);




            CsvController.ReadEachProductByLambda((Product Product) => {
                Debug.WriteLine(Product.AsCsvSafeString());
            });

            Debug.WriteLine("*********** Start Delete ************");

            CsvController.DeleteProductsByLambda((Product Product) => {
                return Product.ID == 1;
            });

            CsvController.ReadEachProductByLambda((Product Product) => {
                Debug.WriteLine(Product.AsCsvSafeString());
            });


            Debug.WriteLine("*********** Done ************");
        }
    }
}

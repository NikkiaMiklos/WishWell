using System.Text;
using System.Diagnostics;

namespace wish_well_1.Controllers
{
    
    public static class CsvController
    {
        private static string productsPath = @"Controllers/Database/Products.csv";
        private static string usersPath = @"Controllers/Database/Users.csv";

        private static List<Product> productsFS = new List<Product>();
        private static List<User> usersFS = new List<User>();

        


        private static int GetNextUserId(List<User> list) {
            var topId = 0;
            foreach(var item in list) {
                if (item.ID > topId) { 
                    topId = item.ID; 
                }
            }
            return topId+1;
        }
        private static int GetNextProductId(List<Product> list) {
            var topId = 0;
            foreach (var item in list) {
                if (item.ID > topId) {
                    topId = item.ID;
                }
            }
            return topId + 1;
        }


        static CsvController() {
            productsFS = LoadProducts(productsPath);
            usersFS = LoadUsers(usersPath);
        }

        private static List<string> LoadCsv(string path) {
            if (File.Exists(path)) {
                var all= File.ReadAllLines(path); 
                var list = new List<string>(all);
                Debug.WriteLine($"~~~~~~~~~~~{list.Count.ToString()}");
                return list;
            } else {
                Debug.WriteLine("!!!!!!!!!!!!file doesn't exist");
                string[] arr = new string[] { };
                return arr.ToList<string>();
            }
        }

        private static bool SaveCsv(string path,List<string> list) {
            try { 
                File.WriteAllLines(path, list.ToArray(), Encoding.UTF8);
                return true;
            }catch(Exception e) {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
        }

        private static List<User> LoadUsers(string path) {
            var sendBack = new List<User>();
            foreach (var user in LoadCsv(path)) {
                sendBack.Add(new User(user));
            }
            Debug.WriteLine(sendBack.Count.ToString());
            return sendBack;
        }

        private static bool SaveUsers() {
            List<string> toSave = new List<string>();
            usersFS.ForEach((item) => {
                toSave.Add(item.AsCsvSafeString());
            });
            return SaveCsv(usersPath,toSave);
        }

        private static List<Product> LoadProducts(string path) {
            var sendBack = new List<Product>();
            foreach (var product in LoadCsv(path)) { 
                sendBack.Add(new Product(product));
            }
            return sendBack;
        }

        private static bool SaveProducts() {
            List<string> toSave = new List<string>();
            productsFS.ForEach((item) => {
                toSave.Add(item.AsCsvSafeString());
            });
            return SaveCsv(productsPath,toSave);
        }

        public static void ReadEachProductByLambda(Action<Product> act) {
            productsFS.ForEach(act);
        }

        public static void ReadEachUserByLambda(Action<User> act) {
            usersFS.ForEach((item) => act(item));
        }

        public static bool AddUser(string name, string email, string pass) {
            var id = GetNextUserId(usersFS);
            usersFS.Add(new User(id,name,email,pass));
            return SaveUsers();
        }

        public static bool AddProduct(string url, string name, string price, int userid) {
            var id = GetNextProductId(productsFS);
            productsFS.Add(new Product(id, url, name, price, userid));
            return SaveProducts();
        }

        public static bool DeleteUsersByLambda(Predicate<User> act) { 
            usersFS.RemoveAll(act);
            return SaveUsers();
        }

        public static bool DeleteProductsByLambda(Predicate<Product> act) {
            productsFS.RemoveAll(act);
            return SaveProducts();
        }

    }
}

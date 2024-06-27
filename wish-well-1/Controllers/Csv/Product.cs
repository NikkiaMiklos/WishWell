using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using static wish_well_1.Controllers.CsvController;

namespace wish_well_1.Controllers
{
    public class ProductCandidate
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int UserId { get; set; }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int UserId { get; set; }
        
        public Product(string csv)
        {

            string[] split = csv.Split(",");
            if (split.Length == 5)
            {
                ID = Convert.ToInt32(Uri.UnescapeDataString(split[0].ToString()));
                Url = Uri.UnescapeDataString(split[1].ToString());
                Name = Uri.UnescapeDataString(split[2].ToString());
                Price = Uri.UnescapeDataString(split[3].ToString());
                UserId = Convert.ToInt32(Uri.UnescapeDataString(split[4].ToString()));
            }
            else
            {
                ID = -1;
                Url = "";
                Name = "";
                Price = "";
                UserId = -1;
            }

        }
        public Product(int id, string url, string name, string price, int userid) { 
            ID = id;
            Url = url;
            Name = name; 
            Price = price;
            UserId = userid;
        }
        public string AsCsvSafeString()
        {
            return $"{Uri.EscapeDataString(ID.ToString())},{Uri.EscapeDataString(Url)},{Uri.EscapeDataString(Name)},{Uri.EscapeDataString(Price)},{Uri.EscapeDataString(UserId.ToString())}";
        }
    }
}

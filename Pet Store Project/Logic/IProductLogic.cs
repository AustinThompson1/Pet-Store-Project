using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Store_Project
{
    internal interface IProductLogic
    {
        public void AddProduct(Product product);
        public List<Product> GetAllProducts();
        public DogLeash GetDogLeashByName(string name);
        public List<string> GetOnlyInStockObjects();
        public decimal GetTotalPriceOfInventory();
    }
}
///The Purpose of Interfaces are to enhance your code for larger scale coding. It is especially great for testing and integration.///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Store_Project
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catFood;

        public ProductLogic()
        {
            _products = new List<Product>();
            _dogLeash = new Dictionary<string, DogLeash>();
            _catFood = new Dictionary<string, CatFood>();

            //init block
            {
                AddProduct( new DogLeash
                {
                    Name = "Cool Leash Bro",
                    Description = "The best leash to exist",
                    Quantity = 15,
                    Price = 100.00m,
                });
                AddProduct(new CatFood
                {
                    Name = "Cat Ice Cream",
                    Description = "Super Tasty",
                    Quantity = 0,
                    Price = 5.99m,
                });
                AddProduct(new CatFood
                {
                    Name = "Kitten Food",
                    Description = "So good a human could eat it... if I ever shared",
                    Quantity = 5,
                    Price = 9.99m,
                });
            } //init block close

        }

        public void AddProduct(Product product)
        {
            if (product is DogLeash)
            {
                _dogLeash.Add(product.Name, product as DogLeash);
            }
            if (product is CatFood)
            {
                _catFood.Add(product.Name, product as CatFood);
            }
            _products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }
        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return _dogLeash[name];
            }
            catch (Exception ex)
            {
                return null;        
            }
        }
        public List<string> GetOnlyInStockObjects()
        {
            return _products
            .InStock()
            .Select(x=>x.Name)
            .ToList();
        }
         public decimal GetTotalPriceOfInventory()
        {
            return _products
                .InStock()
                .Select(x => x.Price)
                .Sum();
        }
    }


}

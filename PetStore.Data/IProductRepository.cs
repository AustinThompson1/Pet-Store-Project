using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public interface IProductRepository
    {
        public interface IProductRepository
        {
            void AddProduct(Product product);
            Product GetProductById(int productId);

            public List<Product> GetAllProducts();
        }

    }
}

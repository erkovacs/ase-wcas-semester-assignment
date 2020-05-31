using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Models
{
    public interface ICategoryProductRepository
    {
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);
        IQueryable<Category> GetCategories();
        IQueryable<Product> GetProducts();
        IQueryable<Product> GetProductsInCategory(int categoryID);
    }
}

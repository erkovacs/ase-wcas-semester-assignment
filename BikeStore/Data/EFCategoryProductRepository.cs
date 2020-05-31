using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Data
{
    public class EFCategoryProductRepository : ICategoryProductRepository
    {
        private ApplicationDbContext context;
        private IProductRepository productRepo;
        private ICategoryRepository categoryRepo;

        public EFCategoryProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            productRepo = new EFProductRepository(ctx);
            categoryRepo = new EFCategoryRepository(ctx);
        }

        public void SaveProduct(Product product) {
            productRepo.SaveProduct(product);
        }

        public Product DeleteProduct(int productID)
        {
            return productRepo.DeleteProduct(productID);
        }

        public IQueryable<Category> GetCategories()
        {
            return categoryRepo.Categories;
        }

        public IQueryable<Product> GetProducts()
        {
            return context.Products;
        }

        public IQueryable<Product> GetProductsInCategory(int categoryID)
        {
            return context.Products.Where(x => x.CategoryID == categoryID);
        }
    }
}

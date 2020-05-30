using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Data
{
    public class EFCategoryRepository
        : ICategoryRepository
    {
        private ApplicationDbContext context;

        public EFCategoryRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Category> Categories => context.Categories;

        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = context.Categories
                    .FirstOrDefault(p => p.CategoryID == category.CategoryID);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                    dbEntry.Description = category.Description;
                }
            }
            context.SaveChanges();
        }

        public Category DeleteCategory(int categoryID)
        {
            Category dbEntry = context.Categories
                    .FirstOrDefault(p => p.CategoryID == categoryID);

            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        // This is what a good colleague once called "facut ca la tara"
        public IQueryable<Product> GetProductsInCategory(int categoryID) {
            return context.Products.Where(x => x.CategoryFK == categoryID);
        }
    }
}

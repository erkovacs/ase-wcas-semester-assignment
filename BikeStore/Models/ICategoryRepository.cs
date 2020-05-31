using System.Collections.Generic;
using System.Linq;

namespace BikeStore.Models
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
        void SaveCategory(Category category);
        Category DeleteCategory(int categoryID);
    }
}

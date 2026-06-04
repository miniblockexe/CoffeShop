using CoffeShop.Data;
using CoffeShop.Models.Interfaces;

namespace CoffeShop.Models.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CoffeeshopDbContext context;
        public CategoryRepository(CoffeeshopDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> GetAllCategories() => context.Categories.ToList();
        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var cat = context.Categories.Find(id);
            if (cat != null) { context.Categories.Remove(cat); context.SaveChanges(); }
        }
    }
}
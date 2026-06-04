namespace CoffeShop.Models.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        void DeleteCategory(int id);
    }
}

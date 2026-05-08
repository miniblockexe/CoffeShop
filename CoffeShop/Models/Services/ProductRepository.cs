using CoffeShop.Data;
using CoffeShop.Models.Interfaces;

namespace CoffeShop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> ProductsList = new List<Product>()
    {
        new Product { Id = 1, Name = "America", Price = 25, Detail = "Name product", ImageUrl = "https://index.com" },
        new Product { Id = 2, Name = "Vietnam", Price = 20, Detail = "Vietnamese product", ImageUrl = "https://index.com" },
        new Product { Id = 3, Name = "United Kingdom", Price = 15, Detail = "Name product", ImageUrl = "https://index.com" }
    };

        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return ProductsList;
        //}

        //public Product GetProductDetail(int id)
        //{
        //    return ProductsList.FirstOrDefault(p => p.Id == id);
        //}

        //public IEnumerable<Product> GetTrendingProducts()
        //{
        //    return ProductsList.Where(p => p.IsTrendingProduct);
        //}

        private CoffeeshopDbContext dbContext;

        public ProductRepository(CoffeeshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products;
        }

        public Product? GetProductDetail(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Products.Where(p => p.IsTrendingProduct);
        }
    }
}
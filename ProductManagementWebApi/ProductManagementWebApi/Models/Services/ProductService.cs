using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext db;
        public ProductService(DataContext db)
        {
            this.db = db;
        }
        public Task<List<Product>> GetAllProductAsync()
        {
            return Task.FromResult(db.Product.ToList());
        }
    }
}

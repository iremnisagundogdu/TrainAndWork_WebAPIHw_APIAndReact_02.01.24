using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Models.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext db;
        public CategoryService(DataContext db)
        {
            this.db = db;
        }
        public Task<List<Category>> GetAllCategoryAsync()
        {
            return Task.FromResult(db.Category.ToList());
        }
    }
}

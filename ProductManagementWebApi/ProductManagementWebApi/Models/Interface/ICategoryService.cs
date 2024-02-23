
namespace ProductManagementWebApi.Models.Interface
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllCategoryAsync();

    }
}

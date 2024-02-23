namespace ProductManagementWebApi.Models.Interface
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProductAsync();
        
    }
}

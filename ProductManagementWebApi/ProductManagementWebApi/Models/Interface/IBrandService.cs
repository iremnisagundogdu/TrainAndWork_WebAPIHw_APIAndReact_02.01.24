namespace ProductManagementWebApi.Models.Interface
{
    public interface IBrandService
    {
        public Task<List<Brand>> GetAllBrandAsync();

    }
}

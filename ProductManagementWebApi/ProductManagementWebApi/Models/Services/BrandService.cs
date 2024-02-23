using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Models.Services
{
    public class BrandService : IBrandService
    {
        private readonly DataContext db;
       public BrandService(DataContext db)
        {
            this.db = db;
        }
        public Task<List<Brand>> GetAllBrandAsync()
        {
            return Task.FromResult(db.Brand.ToList());
        }
    }
}

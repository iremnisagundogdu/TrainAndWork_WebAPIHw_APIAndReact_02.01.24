using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Models.Services
{
    public class ThumbService : IThumbService
    {
        private readonly DataContext db;
        public ThumbService(DataContext db)
        {
            this.db = db;
        }
        public Task<List<Thumb>> GetAllThumbAsync()
        {
            return Task.FromResult(db.Thumb.ToList());
        }
    }
}

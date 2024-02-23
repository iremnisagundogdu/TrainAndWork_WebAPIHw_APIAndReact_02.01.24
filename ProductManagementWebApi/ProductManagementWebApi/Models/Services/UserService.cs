using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Models.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext db;
        public UserService(DataContext db)
        {
            this.db = db;
        }
        public Task<List<User>> GetAllUserAsync()
        {
            return Task.FromResult(db.User.ToList());
        }
    }
}

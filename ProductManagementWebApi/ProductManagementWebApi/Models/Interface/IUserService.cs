namespace ProductManagementWebApi.Models.Interface
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUserAsync();

    }
}

namespace ProductManagementWebApi.Models.Interface
{
    public interface IBlogService
    {
        public Task<List<Blog>> GetAllBlogAsync();

    }
}

using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Models.Services
{
    public class BlogService : IBlogService
    {
        private readonly DataContext db;
        public BlogService(DataContext db) { 
        this.db = db;
        }
        public Task<List<Blog>> GetAllBlogAsync()
        {
            return Task.FromResult(db.Blog.ToList());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApi.Models;
using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }


        [HttpGet("GetBlogs")]
        public async Task< List<Blog>> GetBlogs()
        {
            var blogs = await blogService.GetAllBlogAsync();
            return blogs;

        }
    }
}

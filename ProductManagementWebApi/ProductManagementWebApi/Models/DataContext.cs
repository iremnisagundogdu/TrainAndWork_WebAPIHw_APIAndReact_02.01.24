using Microsoft.EntityFrameworkCore;
using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Thumb> Thumb { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<User> User { get; set; }
        
        



    }
}

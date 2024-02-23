using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApi.Models;
using ProductManagementWebApi.Models.Interface;
using System.Net;

namespace ProductManagementWebApi.Controllers
{
    [Route("api/Category")] // Burada yazan controller direkt bulunduğu controller'ı temsil ediyor.Burası Category'yi temsil ediyor.
    [ApiController] //Attribute olarak geliyor.
    public class CategoryController : ControllerBase // Bu kalıtım, kullanacağımız yapıyı dışarı json olarak verebilmemizi sağlıyor. Bir class yapısı geliyorsa bunu olduğu gibi nesne olarak döndürmez bir json nesnesine convert edip döndürür.
    {

        //private static List<Category> _categories = new List<Category>() // static kullanıyoruz çünkü her yerden erişebilmek için.En son halinde kalmasını istiyorum. Static yapı bunu sağlıyor. Static kullanmasam newlemem gerekecek bu sefer ilk hali gelecek. Bunu istemiyorum.
        //{
        //    new Category(){Id=1, Name="Bilgisayar", IsStatus=true},
        //    new Category(){Id=2, Name="Telefon", IsStatus=true},
        //    new Category(){Id=3, Name="Tablet", IsStatus=true},
        //    new Category(){Id=4, Name="Beyaz Eşya", IsStatus=false},
        //};
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<Category>> Get() //İlk sayfa karşılayan metot Get. Get olarak göndermiş olduğun bir tane metot olması gerekiyor.
        {
            //NOT: IEnumarable ön belleği şişirmez daha verimli kullanır.
            var categories = await categoryService.GetAllCategoryAsync();

            return categories;
        }

        [HttpGet("{id}")] // Bu yapıyı url de kullanamıyoruz bu nedenle postman gibi bir şey kullanmalıyız. Url sadece get yapısıyla çalışır. Post,put delete yapısıyla url kullanılamaz. Bunları kullanabilmek için Postman, Advancer Rest Client benzeri yapı kullanmamız gerekir.
        public async Task<Category> Get(int id)
        {

            var categories = await categoryService.GetAllCategoryAsync();

            Category category = categories.FirstOrDefault(x => x.Id == id);

            return category ;
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] Category value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var categories = await categoryService.GetAllCategoryAsync();

            int maxId = categories.Max(p => p.Id);
            value.Id = maxId + 1;
            categories.Add(value);

            return Ok();
        }

        //[HttpPut("{id}")]
        //public ActionResult Put(int id, [FromBody] Category value)
        //{
        //    var category = categories.FirstOrDefault(x => x.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    category.Name = value.Name;
        //    category.IsStatus = value.IsStatus;

        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    var categories = db.Category.ToList();

        //    var category = categories.FirstOrDefault(x => x.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    categories.Remove(category);

        //    return Ok();
        //}



    }
}

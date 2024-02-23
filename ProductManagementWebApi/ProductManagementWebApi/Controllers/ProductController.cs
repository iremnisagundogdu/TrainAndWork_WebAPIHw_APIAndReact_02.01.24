using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApi.Models;
using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IThumbService thumbService;
        public ProductController(IProductService productService, IThumbService thumbService)
        {
            this.productService = productService;
            this.thumbService = thumbService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            var products = await productService.GetAllProductAsync();
            var thumbs = await thumbService.GetAllThumbAsync();

            foreach (var product in products)
            {
                product.Thumbs = thumbs.Where(t => t.ProductId == product.Id)
                                       .Select(t => new Thumb { Image = t.Image })
                                       .ToList();
            }

            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task< Product> Get(int? id)
        {
            var products = await productService.GetAllProductAsync();

            Product product = products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return product;

            }

            return null;


        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var products = await productService.GetAllProductAsync();


            products.Add(value);

            return Ok();
        }



    }
}

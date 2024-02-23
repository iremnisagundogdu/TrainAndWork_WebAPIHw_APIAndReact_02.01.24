using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApi.Models;
using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet("GetBrands")]
        public async Task<List<Brand>> GetBrands() {
            var brands = await brandService.GetAllBrandAsync();
            return brands;
        
        }


    }
}

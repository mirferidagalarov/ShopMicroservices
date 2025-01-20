using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Entities.DTOs.ProductImageDTOs;
using Shop.Catalog.Services.ProductImageServices;

namespace Shop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageGetAll()
        {
            var data = await _productImageService.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductImageGetById(string id)
        {
            var data = await _productImageService.GetById(id);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> ProductImageDelete(string id)
        {
            await _productImageService.DeleteProductImage(id);  
            return Ok("Data Deleted Successfuly");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDTO createProductImageDTO)
        {
            await _productImageService.CreateProductImage(createProductImageDTO);
            return Ok("Data Added Successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDTO  updateProductImageDTO)
        {
            await _productImageService.UpdateProductImage(updateProductImageDTO);
            return Ok("Data Update Successfuly ");
        }
    }
}

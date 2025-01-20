using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Entities.DTOs.ProductDTOs;
using Shop.Catalog.Services.ProductServices;

namespace Shop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var data =await _productService.GetAll();
            return Ok(data);    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(string id)
        {
            var data =await _productService.GetById(id);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Deleted Successfuly");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productService.AddProductAsync(createProductDTO);
            return Ok("Data Added Successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            await _productService.UpdateProductAsync(updateProductDTO);
            return Ok("Data Updated Successfuly");
        }
    }
}

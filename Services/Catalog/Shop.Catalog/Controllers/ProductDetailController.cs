using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Entities.DTOs.ProductDetailDTOs;
using Shop.Catalog.Services.ProductDetailServices;

namespace Shop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetail()
        {
            var data = await _productDetailService.GetAll();
            return Ok(data); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductDetail(string id)
        {
            var data=await _productDetailService.GetById(id);
            return Ok(data);    
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
           await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Data Deleted Successfuly");    
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDTO createProductDetailDTO)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDTO);
            return Ok("Data Added Successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateProductDetailDTO)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDTO);
            return Ok("Data Update Successfult");
        }
    }
}

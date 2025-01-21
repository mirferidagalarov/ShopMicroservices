using Microsoft.AspNetCore.Mvc;
using Shop.Discount.Entities.DTOs.CouponDTOs;
using Shop.Discount.Services.DiscountService;

namespace Shop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscountCoupon()
        {
            var values=await _discountService.GetAllCouponAsync();    
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDiscountCoupon(int id)
        {
            var values = await _discountService.GetById(id);
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteCouponDTO(id); 
            return Ok("Data Deleted Successfuly");
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDTO createCouponDTO)
        {
            await _discountService.CreateCouponDTO(createCouponDTO);
            return Ok("Data Added Successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDTO updateCouponDTO)
        {
            await _discountService.UpdateCouponDTO(updateCouponDTO);
            return Ok("Data Updated Succcessfuly");    
        }


    }
}

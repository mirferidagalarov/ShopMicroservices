using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Basket.Entities.DTOs;
using Shop.Basket.LoginServices.Abstract;
using Shop.Basket.Services.Abstract;

namespace Shop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;  
        private readonly ILoginService _loginService;
        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;   
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var user = User.Claims;
            var values = _basketService.GetAll(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDTO basketTotalDTO)
        {
            basketTotalDTO.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDTO);    
            return Ok("Basket added completed");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Basket deleted completed");
        }
    }
}

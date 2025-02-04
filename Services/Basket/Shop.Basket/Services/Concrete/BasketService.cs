using Shop.Basket.Entities.DTOs;
using Shop.Basket.Services.Abstract;
using Shop.Basket.Settings;
using System.Text.Json;

namespace Shop.Basket.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId); 
        }

        public async Task<BasketTotalDTO> GetAll(string userId)
        {
            var exsistBasket = await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDTO>(exsistBasket);
        }

        public async Task SaveBasket(BasketTotalDTO basket)
        {
            await _redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
        }
    }
}

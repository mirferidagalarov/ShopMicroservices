using Shop.Basket.Entities.DTOs;

namespace Shop.Basket.Services.Abstract
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetAll(string userId);
        Task SaveBasket(BasketTotalDTO basket);
        Task DeleteBasket(string userId);

    }
}

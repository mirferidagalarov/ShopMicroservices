using Shop.Discount.Entities.DTOs.CouponDTOs;

namespace Shop.Discount.Services.DiscountService
{
    public interface IDiscountService
    {
        Task CreateCouponDTO(CreateCouponDTO createCouponDTO);
        Task UpdateCouponDTO(UpdateCouponDTO updateCouponDTO);
        Task DeleteCouponDTO(int id);
        Task<List<ResultCouponDTO>> GetAllCouponAsync();
        Task<GetByIdCouponDTO> GetById(int id);
    }
}

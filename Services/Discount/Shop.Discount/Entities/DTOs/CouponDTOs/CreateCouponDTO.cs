namespace Shop.Discount.Entities.DTOs.CouponDTOs
{
    public class CreateCouponDTO
    {
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}

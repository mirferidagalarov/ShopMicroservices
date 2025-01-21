using Dapper;
using Shop.Discount.Context;
using Shop.Discount.Entities.DTOs.CouponDTOs;
using Shop.Discount.Services.DiscountService;

namespace Shop.Discount.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;
        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task CreateCouponDTO(CreateCouponDTO createCouponDTO)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDTO.Code);
            parameters.Add("@rate", createCouponDTO.Rate);
            parameters.Add("@isActive", createCouponDTO.IsActive);
            parameters.Add("validDate", createCouponDTO.ValidDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponDTO(int id)
        {
            string query = "Delete from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDTO>> GetAllCouponAsync()
        {
            string query = "Select * from Coupons";
            using(var connection= _dapperContext.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultCouponDTO>(query); 
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDTO> GetById(int id)
        {
            string query = "Select * from Coupons where CouponId=@couponId";
            var parameters=new DynamicParameters();
            parameters.Add("@couponId", id);

            using (var connection=_dapperContext.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetByIdCouponDTO>(query,parameters);
                return values;
            }
        }

        public async Task UpdateCouponDTO(UpdateCouponDTO updateCouponDTO)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDTO.Code);
            parameters.Add("@rate", updateCouponDTO.Rate);
            parameters.Add("@isActive", updateCouponDTO.IsActive);
            parameters.Add("validDate", updateCouponDTO.ValidDate);
            parameters.Add("@couponId", updateCouponDTO.CouponId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

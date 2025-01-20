using Shop.Catalog.Entities.DTOs.ProductDetailDTOs;

namespace Shop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO);
        Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO);
        Task DeleteProductDetailAsync(string id);
        Task<List<ResultProductDetailDTO>> GetAll();
        Task<GetByIdProductDetailDTO> GetById(string id);

        
    }
}

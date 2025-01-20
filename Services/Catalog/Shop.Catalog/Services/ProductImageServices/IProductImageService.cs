using Shop.Catalog.Entities.DTOs.ProductImageDTOs;

namespace Shop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task CreateProductImage(CreateProductImageDTO createProductImageDTO);
        Task UpdateProductImage(UpdateProductImageDTO updateProductImageDTO);
        Task DeleteProductImage(string id);
        Task<List<ResultProductImageDTO>> GetAll();
        Task<GetByIdProductImageDTO> GetById(string id);
    }
}

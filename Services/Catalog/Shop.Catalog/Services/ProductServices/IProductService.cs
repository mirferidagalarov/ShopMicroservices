using Shop.Catalog.Entities.DTOs.ProductDTOs;

namespace Shop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task AddProductAsync(CreateProductDTO createProductDTO);
        Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task DeleteProductAsync(string id);
        Task<List<ResultProductDTO>> GetAll();
        Task<GetByIdProductDTO> GetById(string id);
    }
}

using Shop.Catalog.Entities.DTOs.CategoryDTOs;

namespace Shop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO);
        Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO);
        Task DeleteCategoryAsync(string id);
        Task<List<ResultCategoryDTO>> GetAll();
        Task<GetByIdCategoryDTO> GetById(string id);


    }
}

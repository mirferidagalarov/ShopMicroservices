using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Entities.Concrete;
using Shop.Catalog.Entities.DTOs.CategoryDTOs;
using Shop.Catalog.Settings.Abstract;

namespace Shop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            var value = _mapper.Map<Category>(createCategoryDTO);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
          await _categoryCollection.DeleteOneAsync(id); 
        }

        public async Task<List<ResultCategoryDTO>> GetAll()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDTO>>(values);
        }

        public async Task<GetByIdCategoryDTO> GetById(string id)
        {
            var values = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDTO>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var value=_mapper.Map<Category>(updateCategoryDTO);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDTO.CategoryId, value);
        }
    }
}

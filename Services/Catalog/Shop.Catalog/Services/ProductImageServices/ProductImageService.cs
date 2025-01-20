using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Entities.Concrete;
using Shop.Catalog.Entities.DTOs.ProductImageDTOs;
using Shop.Catalog.Settings.Abstract;

namespace Shop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;
        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductImage(CreateProductImageDTO createProductImageDTO)
        {
            var values = _mapper.Map<ProductImage>(createProductImageDTO);
            await _productImageCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductImage(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDTO>> GetAll()
        {
          var values=await _productImageCollection.Find(x=>true).ToListAsync();
           return _mapper.Map<List<ResultProductImageDTO>>(values);
        }

        public async Task<GetByIdProductImageDTO> GetById(string id)
        {
           var value=await _productImageCollection.Find(x=>x.ProductImageId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDTO>(value);
        }

        public async Task UpdateProductImage(UpdateProductImageDTO updateProductImageDTO)
        {
           var values=_mapper.Map<ProductImage>(updateProductImageDTO);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDTO.ProductImageId, values);
        }
    }
}

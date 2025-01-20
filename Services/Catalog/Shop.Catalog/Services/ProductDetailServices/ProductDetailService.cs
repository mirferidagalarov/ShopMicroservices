using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Entities.Concrete;
using Shop.Catalog.Entities.DTOs.ProductDetailDTOs;
using Shop.Catalog.Settings.Abstract;

namespace Shop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;
        public ProductDetailService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
        {
            var value=_mapper.Map<ProductDetail>(createProductDetailDTO);   
            await _productDetailCollection.InsertOneAsync(value);    
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x=>x.ProductDetailId==id);  
        }

        public async Task<List<ResultProductDetailDTO>> GetAll()
        {
            var value= await _productDetailCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDTO>>(value);
        }

        public async Task<GetByIdProductDetailDTO> GetById(string id)
        {
            var value = await _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDTO>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDTO);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDTO.ProductDetailId, value);
        }
    }
}

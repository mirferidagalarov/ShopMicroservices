using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Entities.Concrete;
using Shop.Catalog.Entities.DTOs.ProductDTOs;
using Shop.Catalog.Settings.Abstract;
using Shop.Catalog.Settings.Concrete;

namespace Shop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection; 
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;   
        }

        public async Task AddProductAsync(CreateProductDTO createProductDTO)
        {
            var data=_mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(data);  
        }

        public async Task DeleteProductAsync(string id)
        {
           await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDTO>> GetAll()
        {
            var values=await _productCollection.Find(x=>true).ToListAsync();   
            return _mapper.Map<List<ResultProductDTO>>(values);
        }

        public async Task<GetByIdProductDTO> GetById(string id)
        {
            var values=await _productCollection.Find(x=>x.ProductId ==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDTO>(values);

        }

        public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            var values=_mapper.Map<Product>(updateProductDTO);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId==updateProductDTO.ProductId,values);
        }
    }
}

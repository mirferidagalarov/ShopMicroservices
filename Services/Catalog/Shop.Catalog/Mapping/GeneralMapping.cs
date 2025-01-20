using AutoMapper;
using Shop.Catalog.Entities.Concrete;
using Shop.Catalog.Entities.DTOs.CategoryDTOs;
using Shop.Catalog.Entities.DTOs.ProductDetailDTOs;
using Shop.Catalog.Entities.DTOs.ProductDTOs;
using Shop.Catalog.Entities.DTOs.ProductImageDTOs;

namespace Shop.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            #region Category
            CreateMap<Category,ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDTO>().ReverseMap();
            #endregion

            #region Product
            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, GetByIdProductDTO>().ReverseMap();
            #endregion

            #region ProductDetail
            CreateMap<ProductDetail, ResultProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDTO>().ReverseMap();
            #endregion

            #region ProductImage
            CreateMap<ProductImage, ResultProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDTO>().ReverseMap();
            #endregion

        }
    }
}

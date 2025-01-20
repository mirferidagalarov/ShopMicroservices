namespace Shop.Catalog.Entities.DTOs.ProductDTOs
{
    public class GetByIdProductDTO
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}

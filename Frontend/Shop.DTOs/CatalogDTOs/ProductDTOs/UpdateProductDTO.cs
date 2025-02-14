using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTOs.CatalogDTOs.ProductDTOs
{
    public class UpdateProductDTO
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

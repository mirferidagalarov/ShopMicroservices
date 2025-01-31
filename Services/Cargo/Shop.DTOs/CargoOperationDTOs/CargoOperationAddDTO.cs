using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTOs.CargoOperationDTOs
{
    public class CargoOperationAddDTO
    {
        public string BarCode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}

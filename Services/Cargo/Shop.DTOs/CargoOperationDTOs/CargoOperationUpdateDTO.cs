using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTOs.CargoOperationDTOs
{
    public class CargoOperationUpdateDTO
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}

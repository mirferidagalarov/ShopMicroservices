using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTOs.CargoDetailDTOs
{
    public class CargoDetailAddDTO
    {
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int BarCode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}

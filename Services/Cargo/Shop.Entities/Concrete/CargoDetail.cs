using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.Concrete
{
    public class CargoDetail
    {
        public int Id {  get; set; }    
        public string SenderCustomer {  get; set; } 
        public string ReceiverCustomer {  get; set; }   
        public int BarCode {  get; set; }   
        public int CargoCompanyId {  get; set; }    
        public CargoCompany CargoCompany { get; set; }  
    }
}

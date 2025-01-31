﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.Concrete
{
    public class CargoOperation
    {
        public int Id { get; set; } 
        public string BarCode {  get; set; }    
        public string Description {  get; set; }    
        public DateTime OperationDate { get; set; }
    }
}

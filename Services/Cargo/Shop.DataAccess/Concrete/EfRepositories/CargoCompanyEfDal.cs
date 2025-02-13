﻿using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.DataContext;
using Shop.DataAccess.Concrete.Repositories;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Concrete.EfRepositories
{
    public class CargoCompanyEfDal:GenericRepository<CargoCompany>,ICargoCompanyDal
    {
        private readonly CargoContext _cargoContext;
        public CargoCompanyEfDal(CargoContext cargoContext):base(cargoContext)
        {
            _cargoContext = cargoContext;
        }
    }
}

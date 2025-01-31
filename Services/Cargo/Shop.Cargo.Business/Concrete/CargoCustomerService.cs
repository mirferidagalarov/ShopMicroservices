using Shop.Cargo.Business.Abstract;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Cargo.Business.Concrete
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly ICargoCustomerDal  _cargoCustomerDal;

        public CargoCustomerService(ICargoCustomerDal  cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }
        public void TAdd(CargoCustomer entity)
        {
            _cargoCustomerDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _cargoCustomerDal.Delete(id);   
        }

        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomerDal.GetAll();  
        }

        public CargoCustomer TGetById(int id)
        {
            return _cargoCustomerDal.GetById(id);   
        }

        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomerDal.Update(entity);   
        }
    }
}
